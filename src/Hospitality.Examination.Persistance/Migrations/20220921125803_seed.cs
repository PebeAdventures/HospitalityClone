using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Examination.Persistance.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "USG kolana");

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "USG jamy brzusznej");

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "RTG głowy");

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "RTG zębów");

            migrationBuilder.InsertData(
                table: "ExaminationTypes",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[,]
                {
                    { 5, 60000000L, "RTG styczne czaszki" },
                    { 6, 60000000L, "Leczenie kanałowe zębów" },
                    { 7, 80000000L, "Badanie kału na pasożyty" },
                    { 8, 100000000L, "Cytologia płynna" },
                    { 9, 70000000L, "Echo serca" },
                    { 10, 60000000L, "Gastroskopia" },
                    { 11, 60000000L, "Hashimoto" },
                    { 12, 60000000L, "HPV test" },
                    { 13, 60000000L, "Żelazo (krew)" },
                    { 14, 60000000L, "Witamina B12" },
                    { 15, 60000000L, "Wzrok" },
                    { 16, 60000000L, "Test na HIV" },
                    { 17, 60000000L, "Spirometria podstawowa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "laryngologist");

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "dentist");

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "orthopedist");

            migrationBuilder.UpdateData(
                table: "ExaminationTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "nephrologist");

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "Description", "ExaminationTypeId", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, "Checking if your hearing is good", 1, 1, 1 },
                    { 2, "Checking the teeth", 2, 2, 1 },
                    { 3, "Examination of the musculoskeletal system", 3, 3, 2 },
                    { 4, "Renal function test", 4, 4, 2 }
                });
        }
    }
}
