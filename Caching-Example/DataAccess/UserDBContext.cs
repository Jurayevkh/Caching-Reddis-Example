using Caching_Example.Configuration;
using Caching_Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Caching_Example.DataAccess
{
	public class UserDBContext:DbContext
	{
		public UserDBContext(DbContextOptions<UserDBContext> options):base(options)
		{

		}

		public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
		}
    }
}

