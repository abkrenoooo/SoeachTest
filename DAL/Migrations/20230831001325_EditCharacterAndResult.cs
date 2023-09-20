using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class EditCharacterAndResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Results",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Results",
                newName: "ChearState");

            migrationBuilder.RenameIndex(
                name: "IX_Results_TestId",
                table: "Results",
                newName: "IX_Results_ChearId");

            migrationBuilder.AddColumn<int>(
                name: "AnotherCharacter",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChearPositionResult",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Character",
                table: "Chears",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChearPosition",
                table: "Chears",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Chears",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHiden",
                table: "Chears",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Chears_ChearId",
                table: "Results",
                column: "QuestionId",
                principalTable: "Chears",
                principalColumn: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Chears_ChearId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "AnotherCharacter",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ChearPositionResult",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Character",
                table: "Chears");

            migrationBuilder.DropColumn(
                name: "ChearPosition",
                table: "Chears");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Chears");

            migrationBuilder.DropColumn(
                name: "IsHiden",
                table: "Chears");

            migrationBuilder.RenameColumn(
                name: "ChearState",
                table: "Results",
                newName: "Degree");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Results",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ChearId",
                table: "Results",
                newName: "IX_Results_TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Tests_TestId",
                table: "Results",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId");
        }
    }
}
