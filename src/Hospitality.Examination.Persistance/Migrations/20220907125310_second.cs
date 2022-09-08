using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Examination.API.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_TypeId",
                table: "Examinations");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Examinations",
                newName: "ExaminationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_TypeId",
                table: "Examinations",
                newName: "IX_Examinations_ExaminationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_ExaminationTypeId",
                table: "Examinations",
                column: "ExaminationTypeId",
                principalTable: "ExaminationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_ExaminationTypeId",
                table: "Examinations");

            migrationBuilder.RenameColumn(
                name: "ExaminationTypeId",
                table: "Examinations",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_ExaminationTypeId",
                table: "Examinations",
                newName: "IX_Examinations_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_TypeId",
                table: "Examinations",
                column: "TypeId",
                principalTable: "ExaminationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
