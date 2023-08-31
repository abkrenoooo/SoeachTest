using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class EditCharacterAndResult01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_TestId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TestId",
                table: "Patients",
                column: "TestId",
                unique: true,
                filter: "[TestId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_TestId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TestId",
                table: "Patients",
                column: "TestId");
        }
    }
}
