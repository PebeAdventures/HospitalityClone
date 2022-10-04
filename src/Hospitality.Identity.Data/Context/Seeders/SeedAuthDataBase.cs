using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SecondExam.AuthContext.Context.Seeders
{
    public static class SeedAuthDataBase
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<IdentityRole> identityRoles = new List<IdentityRole>()
            {
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Doctor", NormalizedName = "DOCTOR" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Receptionist", NormalizedName = "RECEPTIONIST" }
            };
            List<IdentityUser> identityUsers = new List<IdentityUser>()
            {
                new IdentityUser {Id = Guid.NewGuid().ToString(), UserName = "Dr. House", Email = "doctor", NormalizedEmail = "DOCTOR"},
                new IdentityUser {Id = Guid.NewGuid().ToString(), UserName = "Danuta Nowak", Email = "receptionist", NormalizedEmail = "RECEPTIONIST"}

            };
            var user = identityUsers[0];
            var admin = identityUsers[1];

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "doctor");
            admin.PasswordHash = ph.HashPassword(admin, "receptionist");

            List<IdentityUserRole<string>> identityUserRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles[0].Id,
                    UserId = identityUsers[0].Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles[1].Id,
                    UserId = identityUsers[1].Id,
                }
            };

            modelBuilder.Entity<IdentityRole>()
                .HasData(identityRoles);
            modelBuilder.Entity<IdentityUser>()
                .HasData(identityUsers);
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(identityUserRoles);
        }
    }
}
