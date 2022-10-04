﻿using Microsoft.AspNetCore.Identity;
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
                new IdentityUser {Id = Guid.NewGuid().ToString(), UserName = "Dr. Dolittle", Email = "dolittle", NormalizedEmail = "DOLITTLE"},
                new IdentityUser {Id = Guid.NewGuid().ToString(), UserName = "Dr. oetker", Email = "oetker", NormalizedEmail = "OETKER"},
                new IdentityUser {Id = Guid.NewGuid().ToString(), UserName = "Danuta Nowak", Email = "receptionist", NormalizedEmail = "RECEPTIONIST"},
                new IdentityUser {Id = Guid.NewGuid().ToString(), UserName = "Rafał Wyrwikoński", Email = "rafik", NormalizedEmail = "RAFIK"}

            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            identityUsers[0].PasswordHash = ph.HashPassword(identityUsers[0], "doctor");
            identityUsers[0].PasswordHash = ph.HashPassword(identityUsers[1], "dolittle");
            identityUsers[0].PasswordHash = ph.HashPassword(identityUsers[2], "oetker");
            identityUsers[3].PasswordHash = ph.HashPassword(identityUsers[3], "receptionist");
            identityUsers[3].PasswordHash = ph.HashPassword(identityUsers[4], "rafik");

            List<IdentityUserRole<string>> identityUserRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles[0].Id,
                    UserId = identityUsers[0].Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles[0].Id,
                    UserId = identityUsers[1].Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles[0].Id,
                    UserId = identityUsers[2].Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles[1].Id,
                    UserId = identityUsers[3].Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles[1].Id,
                    UserId = identityUsers[4].Id,
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
