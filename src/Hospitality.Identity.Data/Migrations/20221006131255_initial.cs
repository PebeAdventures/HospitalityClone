using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Identity.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb37470a-e9ba-4db6-ac77-36068236fcdd", "a39c518b-2174-4a12-8ba6-9212b21a800d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5dda6473-4e0e-4aa0-8fc5-12a14d6fb8c6", "bfa6e69c-054b-4c13-a38a-cda77dd8d713" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dda6473-4e0e-4aa0-8fc5-12a14d6fb8c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb37470a-e9ba-4db6-ac77-36068236fcdd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a39c518b-2174-4a12-8ba6-9212b21a800d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfa6e69c-054b-4c13-a38a-cda77dd8d713");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "489e7461-c152-42cc-a19c-41c033773b23", "075dd9b9-e38d-4f1d-be45-bd4bb4a76e90", "Doctor", "DOCTOR" },
                    { "7761f598-77cc-40a6-9f3a-a1867ca04362", "ea1f053b-57d4-4267-8fc0-8c78385eda8f", "Receptionist", "RECEPTIONIST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "35c426aa-d574-45bd-bc33-c68a432523b2", 0, "6dcbf1ef-4bfa-40dd-9be3-0975e1f4d43a", "rafik", false, false, null, "RAFIK", null, "AQAAAAEAACcQAAAAEMlDIq/bTg2RC3G+/1/0D9ZrD96V+/4W8nV9mg0JbGzz6BImiYTBm0Ht8oK3TzPrdw==", null, false, "e0ef1b2e-c827-44cf-8c3c-cd667451e841", false, "Rafał Wyrwikoński" },
                    { "3798b373-3f00-4988-87c6-7ffac1d8c208", 0, "047e817b-4a5b-4c27-89ea-a5a97d89b1c4", "doctor", false, false, null, "DOCTOR", null, "AQAAAAEAACcQAAAAENhLHqF7Ih+4q4NtrLWa9S0bGg1qYHOrvg8fRifEStUywutIrdMlZCu5xCj2xZdpuA==", null, false, "6d757a7b-6d43-437b-8d8e-ca158c8d88f8", false, "Dr. House" },
                    { "658d6515-9ab3-4454-9e8a-5eeeecda484c", 0, "377f19f6-40b8-4d90-b786-8e22204a64a4", "dolittle", false, false, null, "DOLITTLE", null, "AQAAAAEAACcQAAAAEGKvmwZ6ETSh0xp5YfCpEsKuow6AJFhbrBIKHXhSncuw9Kt4RaLrIgeTvBkfAbqX8Q==", null, false, "9ec89c33-a7e3-42b6-854a-eaf3eb2756cc", false, "Dr. Dolittle" },
                    { "e09df49e-f891-4062-bc43-9e4aa5e39391", 0, "84814a2c-a2b9-416f-be17-f19c16a322da", "receptionist", false, false, null, "RECEPTIONIST", null, "AQAAAAEAACcQAAAAEHy+qim1sm8CbuXCFHFdhKYXj/jJZKSxcEeYvMgMQaSQeJs4SWd0YofTYTqKtEoEBg==", null, false, "c0284d9a-2f38-40b0-8bc2-d5875a77f89b", false, "Danuta Nowak" },
                    { "e5c80ea0-a08c-40c2-b6b2-1674d5160038", 0, "5c7331be-09ba-48c7-98ae-73424d8a5bec", "oetker", false, false, null, "OETKER", null, "AQAAAAEAACcQAAAAEMSo471/w2e4V6LV68qJfMMapjfaakJbYBwP9BFRXoenfXbhkx7fxzXTU/PG4n6ccA==", null, false, "9746c5db-bff1-4f8b-9e85-33bf5f43e985", false, "Dr. oetker" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7761f598-77cc-40a6-9f3a-a1867ca04362", "35c426aa-d574-45bd-bc33-c68a432523b2" },
                    { "489e7461-c152-42cc-a19c-41c033773b23", "3798b373-3f00-4988-87c6-7ffac1d8c208" },
                    { "489e7461-c152-42cc-a19c-41c033773b23", "658d6515-9ab3-4454-9e8a-5eeeecda484c" },
                    { "7761f598-77cc-40a6-9f3a-a1867ca04362", "e09df49e-f891-4062-bc43-9e4aa5e39391" },
                    { "489e7461-c152-42cc-a19c-41c033773b23", "e5c80ea0-a08c-40c2-b6b2-1674d5160038" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7761f598-77cc-40a6-9f3a-a1867ca04362", "35c426aa-d574-45bd-bc33-c68a432523b2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "489e7461-c152-42cc-a19c-41c033773b23", "3798b373-3f00-4988-87c6-7ffac1d8c208" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "489e7461-c152-42cc-a19c-41c033773b23", "658d6515-9ab3-4454-9e8a-5eeeecda484c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7761f598-77cc-40a6-9f3a-a1867ca04362", "e09df49e-f891-4062-bc43-9e4aa5e39391" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "489e7461-c152-42cc-a19c-41c033773b23", "e5c80ea0-a08c-40c2-b6b2-1674d5160038" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489e7461-c152-42cc-a19c-41c033773b23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7761f598-77cc-40a6-9f3a-a1867ca04362");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35c426aa-d574-45bd-bc33-c68a432523b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3798b373-3f00-4988-87c6-7ffac1d8c208");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "658d6515-9ab3-4454-9e8a-5eeeecda484c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e09df49e-f891-4062-bc43-9e4aa5e39391");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5c80ea0-a08c-40c2-b6b2-1674d5160038");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5dda6473-4e0e-4aa0-8fc5-12a14d6fb8c6", "d3e79d9d-cad5-417f-bf5a-584a35203611", "Doctor", "DOCTOR" },
                    { "fb37470a-e9ba-4db6-ac77-36068236fcdd", "4b18777b-d294-4a45-8889-5f0e807596de", "Receptionist", "RECEPTIONIST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a39c518b-2174-4a12-8ba6-9212b21a800d", 0, "faedb380-d6bc-44ad-9271-a0df6c67e420", "receptionist", false, false, null, "RECEPTIONIST", null, "AQAAAAEAACcQAAAAEFCaG77SFb3WEhKEE/uBYxl/fj5lnDi2kiv1CaDUo/Cggf7wjUUJK+v/wQDv+Aw+6w==", null, false, "4780b93f-11d3-493b-8dda-fc166a6196c6", false, "Danuta Nowak" },
                    { "bfa6e69c-054b-4c13-a38a-cda77dd8d713", 0, "d0862d16-fe7a-44d5-96c4-cec929a013e7", "doctor", false, false, null, "DOCTOR", null, "AQAAAAEAACcQAAAAEHVOqYsH8aGrFpZMWcfpZ4NankrP83IbNLW4SWL3AAJfOIqgGjEq7gMSDpXlEwQNmQ==", null, false, "9dd3aa4f-047d-4b4a-9aeb-7ad29ddf04d6", false, "Dr. House" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fb37470a-e9ba-4db6-ac77-36068236fcdd", "a39c518b-2174-4a12-8ba6-9212b21a800d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5dda6473-4e0e-4aa0-8fc5-12a14d6fb8c6", "bfa6e69c-054b-4c13-a38a-cda77dd8d713" });
        }
    }
}
