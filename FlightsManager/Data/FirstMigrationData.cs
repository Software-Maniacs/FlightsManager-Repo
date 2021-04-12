using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Data
{
    public static class FirstMigrationData
    {
        public static void SeedData()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            if (db.UserRoles.ToList().Count == 0)
            {
                string roleID = Guid.NewGuid().ToString();
                string userID = Guid.NewGuid().ToString();

                db.Roles.Add(new IdentityRole()
                {
                    Id = roleID,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

                db.Roles.Add(new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

                ApplicationUser user = new ApplicationUser()
                {
                    Id = userID,
                    UserName = "administrator",
                    NormalizedUserName = "ADMINISTRATOR",
                    Email = "managerflight31@gmail.com",
                    NormalizedEmail = "MANAGERFLIGHT31@GMAIL.COM",
                    EmailConfirmed = true
                };

                IPasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
                string hash = hasher.HashPassword(user, "Admin123!");

                user.PasswordHash = hash;

                db.Users.Add(user);

                db.UserRoles.Add(new IdentityUserRole<string>()
                {
                    RoleId = roleID,
                    UserId = userID
                });

                db.SaveChangesAsync();
            }
        }
    }
}
