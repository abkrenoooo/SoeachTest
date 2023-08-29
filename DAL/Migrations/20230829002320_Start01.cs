using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Start01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chears_Tests_TestId1",
                table: "Chears");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Specialists_SpecialistId1",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_SpecialistId1",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Chears_TestId1",
                table: "Chears");

            migrationBuilder.DropColumn(
                name: "FullMark",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SpecialistId1",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SuccessMark",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestDescription",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestFaildResult",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestMaterials",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestSuccesResult",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestId1",
                table: "Chears");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialistId",
                table: "Tests",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Tests",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "Chears",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SpecialistId",
                table: "Tests",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Chears_TestId",
                table: "Chears",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chears_Tests_TestId",
                table: "Chears",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Specialists_SpecialistId",
                table: "Tests",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "SpecialistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chears_Tests_TestId",
                table: "Chears");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Specialists_SpecialistId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_SpecialistId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Chears_TestId",
                table: "Chears");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialistId",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FullMark",
                table: "Tests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialistId1",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SuccessMark",
                table: "Tests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestDescription",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TestFaildResult",
                table: "Tests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestMaterials",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TestSuccesResult",
                table: "Tests",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestId",
                table: "Chears",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId1",
                table: "Chears",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SpecialistId1",
                table: "Tests",
                column: "SpecialistId1");

            migrationBuilder.CreateIndex(
                name: "IX_Chears_TestId1",
                table: "Chears",
                column: "TestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Chears_Tests_TestId1",
                table: "Chears",
                column: "TestId1",
                principalTable: "Tests",
                principalColumn: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Specialists_SpecialistId1",
                table: "Tests",
                column: "SpecialistId1",
                principalTable: "Specialists",
                principalColumn: "SpecialistId");
        }
    }
}
