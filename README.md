# 🚀 Caching Redis Example

A delightful project showcasing the power of caching with Redis in a .NET application.

## 🌟 Overview

Explore the magic of Redis caching in this .NET application. Dive into the organized folders to uncover the secrets:

- **🎮 Controllers:** The `UserControllers` folder hosts the mighty `UserControllers` with its legendary `GetById` method, armed with the ancient knowledge of data caching.

- **🧰 Configuration:** The `configuration` folder safeguards the fluent API for the legendary `User` model, ensuring the seamless seeding of data into the User table.

- **🛠️ DataAccess:** The `DataAccess` folder orchestrates the connection to the database and calls the mystical fluent APIs for configuration.

- **📚 Models:** Behold the `Models` folder, the realm of the noble `User` model defining the essence of the User entity.

## 🎮 Controllers

### UserControllers

#### GetById Method

The `GetById` method in the `UserControllers` controller is a masterpiece, wielding the ancient art of caching with Redis in the realm of .NET.

```csharp
public class UserControllers : ControllerBase
{

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
```

## 🛠️ Usage

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/Jurayevkh/Caching-Reddis-Example.git
