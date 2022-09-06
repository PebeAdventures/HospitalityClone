using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Identity.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d1c7263-1e62-4349-84ab-7ee04c1fcb4b", "10bf23da-8073-40dd-9261-0adee6580ad9", "Receptionist", "RECEPTIONIST" },
                    { "d83e41da-d411-4611-abf5-cd62082da280", "ef2bb008-7ca1-4637-8614-7d7f15b2bb6f", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a46b7567-acea-4f6a-b2b9-f150628ec4d2", 0, "19d7ae9f-cc34-4a30-a870-32049cf05e16", "doctor", false, false, null, "DOCTOR", null, "AQAAAAEAACcQAAAAELmifSZCxJ1Kw2Y17WNN3CSUQlXRu/8zgpRY2NzWO1NQzXgkAgrpsJtVlWJiOQ2bXA==", null, false, "acd7ce06-6e2a-403d-8196-594f69e6a83f", false, null },
                    { "ce94c882-6b05-4be0-85b3-9ca0aa46111b", 0, "94c35aa6-f141-4395-a85e-8dbf6590f5c9", "receptionist", false, false, null, "RECEPTIONIST", null, "AQAAAAEAACcQAAAAENj61q64OmPJQGjVzTwX1+jXw/EX/iJrcUJBy+Yn4xWE/lJa1TjvU3lwx2usUOqkwQ==", null, false, "3864915c-870e-4c16-8a92-2cbe93afbc72", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d83e41da-d411-4611-abf5-cd62082da280", "a46b7567-acea-4f6a-b2b9-f150628ec4d2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1d1c7263-1e62-4349-84ab-7ee04c1fcb4b", "ce94c882-6b05-4be0-85b3-9ca0aa46111b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d83e41da-d411-4611-abf5-cd62082da280", "a46b7567-acea-4f6a-b2b9-f150628ec4d2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1d1c7263-1e62-4349-84ab-7ee04c1fcb4b", "ce94c882-6b05-4be0-85b3-9ca0aa46111b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d1c7263-1e62-4349-84ab-7ee04c1fcb4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d83e41da-d411-4611-abf5-cd62082da280");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a46b7567-acea-4f6a-b2b9-f150628ec4d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce94c882-6b05-4be0-85b3-9ca0aa46111b");
        }
    }
}
