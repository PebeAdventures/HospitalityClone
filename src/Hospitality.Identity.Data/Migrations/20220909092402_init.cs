using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Identity.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "629247f3-864d-4be4-b007-dfd3d52bf551", "2c358142-8eb3-4823-94bd-c6e449823edb", "Receptionist", "RECEPTIONIST" },
                    { "c0ba21c2-c9a5-4ff8-bb94-a5306b5b034c", "02edb17e-d66d-4d70-8cdb-38726bc820dc", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6389cb46-509d-4f02-bdc1-ace095562a88", 0, "d9d72235-0aa8-430e-a328-884ec8281f88", "doctor", false, false, null, "DOCTOR", null, "AQAAAAEAACcQAAAAEMxTKDawJFKWt9urrjpyvnO3uSXBb5d/tfCfPpBnpM1zU/rnl31pQUyJT93co53Udw==", null, false, "ea64f1cc-8ae4-44af-b30f-4c4053a93a52", false, null },
                    { "9981f0d7-9683-4fae-b64c-02452819c54a", 0, "0606e197-be74-4c52-9a17-57e8907128ef", "receptionist", false, false, null, "RECEPTIONIST", null, "AQAAAAEAACcQAAAAEL21wKq07qyQsERI+f2A2A1adwWPcuWMbPvSP2I5uItV+3xmkLwhniFV3LqOhtC08Q==", null, false, "628a473b-4c15-4527-9f84-8deae7f6ed87", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c0ba21c2-c9a5-4ff8-bb94-a5306b5b034c", "6389cb46-509d-4f02-bdc1-ace095562a88" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "629247f3-864d-4be4-b007-dfd3d52bf551", "9981f0d7-9683-4fae-b64c-02452819c54a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c0ba21c2-c9a5-4ff8-bb94-a5306b5b034c", "6389cb46-509d-4f02-bdc1-ace095562a88" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "629247f3-864d-4be4-b007-dfd3d52bf551", "9981f0d7-9683-4fae-b64c-02452819c54a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629247f3-864d-4be4-b007-dfd3d52bf551");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ba21c2-c9a5-4ff8-bb94-a5306b5b034c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6389cb46-509d-4f02-bdc1-ace095562a88");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9981f0d7-9683-4fae-b64c-02452819c54a");

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
    }
}
