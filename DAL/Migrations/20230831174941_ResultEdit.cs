using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ResultEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ChearPositionResult",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_PatientId",
                table: "Results",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Patients_PatientId",
                table: "Results",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Patients_PatientId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_PatientId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "ChearPositionResult",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
