using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Identity.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1cdbb127-643a-4d21-baf5-1b34efad6800", "740eea5a-f86b-4322-ab56-d7e273382005", "Receptionist", "RECEPTIONIST" },
                    { "56faf606-bdfd-497c-b186-ac3d7b5744e5", "987bfb1f-b310-406c-bab1-01865f501992", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "12d92ee4-36d4-4b43-907f-5f66501bb6af", 0, "b4380886-48e9-4d5d-bbe3-25f2e577d5c2", "doctor", false, false, null, "DOCTOR", null, "AQAAAAEAACcQAAAAECs+v/SGQxOqIZD5lF+0k9oFYF//0xSbf1M6R/qYiyoSL6H/eSU01EIMkwhv0VDFvg==", null, false, "7219a685-8d81-4b1a-9861-a431c9bd835f", false, null },
                    { "2b4f7dc2-eae9-4c13-b3cc-3d606ce24f6c", 0, "b0cf1767-f7b9-484f-8e0a-6afad4fb0cc6", "receptionist", false, false, null, "RECEPTIONIST", null, "AQAAAAEAACcQAAAAEIPWKepclV5elGMoGqQ0v8rsCUVFBsIcWyYXl8/xzC3olJvL+LKSxXb0KY/rinsAhQ==", null, false, "2db859f9-d0b4-437f-9c2b-5986bbee629a", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "56faf606-bdfd-497c-b186-ac3d7b5744e5", "12d92ee4-36d4-4b43-907f-5f66501bb6af" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1cdbb127-643a-4d21-baf5-1b34efad6800", "2b4f7dc2-eae9-4c13-b3cc-3d606ce24f6c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56faf606-bdfd-497c-b186-ac3d7b5744e5", "12d92ee4-36d4-4b43-907f-5f66501bb6af" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1cdbb127-643a-4d21-baf5-1b34efad6800", "2b4f7dc2-eae9-4c13-b3cc-3d606ce24f6c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cdbb127-643a-4d21-baf5-1b34efad6800");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56faf606-bdfd-497c-b186-ac3d7b5744e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12d92ee4-36d4-4b43-907f-5f66501bb6af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4f7dc2-eae9-4c13-b3cc-3d606ce24f6c");

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
    }
}
