using Caching_Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caching_Example.Configuration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Age).IsRequired();


            builder.HasData(
               new User { Id = 1, FirstName = "John", LastName = "Doe", UserName = "john_doe", Age = 30 },
               new User { Id = 2, FirstName = "Jane", LastName = "Smith", UserName = "jane_smith", Age = 25 },
               new User { Id = 3, FirstName = "Bob", LastName = "Johnson", UserName = "bob_johnson", Age = 35 },
               new User { Id = 4, FirstName = "Alice", LastName = "Williams", UserName = "alice_williams", Age = 28 },
               new User { Id = 5, FirstName = "Charlie", LastName = "Brown", UserName = "charlie_brown", Age = 32 },
               new User { Id = 6, FirstName = "Eva", LastName = "Davis", UserName = "eva_davis", Age = 23 },
               new User { Id = 7, FirstName = "Frank", LastName = "Miller", UserName = "frank_miller", Age = 40 },
               new User { Id = 8, FirstName = "Grace", LastName = "Moore", UserName = "grace_moore", Age = 26 },
               new User { Id = 9, FirstName = "Harry", LastName = "Clark", UserName = "harry_clark", Age = 33 },
               new User { Id = 10, FirstName = "Ivy", LastName = "Turner", UserName = "ivy_turner", Age = 29 }
                            );
        }
    }
}

