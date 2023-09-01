using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addSpecialistinRuslt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialistId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_SpecialistId",
                table: "Results",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Specialists_SpecialistId",
                table: "Results",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "SpecialistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Specialists_SpecialistId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_SpecialistId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Results");
        }
    }
}
