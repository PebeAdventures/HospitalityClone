using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Patient.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    HospitalPatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInsured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.HospitalPatientId);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "HospitalPatientId", "Address", "BirthDate", "Email", "IsInsured", "PatientName", "PatientPesel", "PatientSurname", "PhoneNumber" },
                values: new object[] { 1, "Wrzosowa", new DateTime(1999, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "aniela.nowak@gmail.com", true, "Aniela", "99112234543", "Nowak", "213769420" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
