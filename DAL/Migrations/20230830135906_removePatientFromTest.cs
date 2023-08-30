using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class removePatientFromTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_TestId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Tests");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TestId",
                table: "Patients",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_TestId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TestId",
                table: "Patients",
                column: "TestId",
                unique: true,
                filter: "[TestId] IS NOT NULL");
        }
    }
}
