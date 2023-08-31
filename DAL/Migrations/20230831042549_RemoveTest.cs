using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class RemoveTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chears_Tests_TestId",
                table: "Chears");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Tests_TestId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_QuctionTests_Tests_TestId",
                table: "QuctionTests");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_QuctionTests_TestId",
                table: "QuctionTests");

            migrationBuilder.DropIndex(
                name: "IX_Patients_TestId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Chears_TestId",
                table: "Chears");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "QuctionTests");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Chears");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Patients",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "QuctionTests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Chears",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialistId = table.Column<int>(type: "int", nullable: true),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "SpecialistId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuctionTests_TestId",
                table: "QuctionTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TestId",
                table: "Patients",
                column: "TestId",
                unique: true,
                filter: "[TestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chears_TestId",
                table: "Chears",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SpecialistId",
                table: "Tests",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chears_Tests_TestId",
                table: "Chears",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Tests_TestId",
                table: "Patients",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuctionTests_Tests_TestId",
                table: "QuctionTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId");
        }
    }
}
