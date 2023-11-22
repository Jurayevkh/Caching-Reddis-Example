using System.Text.Json;
using Caching_Example.DataAccess;
using Caching_Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Caching_Example.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        private readonly UserDBContext _userDBContext;

        public UserController(IDistributedCache distributedCache, UserDBContext userDBContext)
        {
            _distributedCache = distributedCache;
            _userDBContext = userDBContext;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetById(int id)
        {
            var fromCache = await _distributedCache.GetStringAsync($"{id}");

            if (fromCache is null)
            {
                var values = _userDBContext.Users.FirstOrDefault(user => user.Id == id);

                fromCache = JsonSerializer.Serialize(values);
                await _distributedCache.SetStringAsync($"{values.Id}", fromCache,new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow=TimeSpan.FromSeconds(60)
                });

            }

            var result = JsonSerializer.Deserialize<User>(fromCache);
            return Ok(result);
        }
    }
}

