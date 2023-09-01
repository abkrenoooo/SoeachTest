using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class deleteResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuctionTests");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Chears");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ChearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterPosition = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<int>(type: "int", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHiden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ChearId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.CreateTable(
                name: "Chears",
                columns: table => new
                {
                    ChearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Character = table.Column<int>(type: "int", nullable: false),
                    ChearPosition = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHiden = table.Column<bool>(type: "bit", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chears", x => x.ChearId);
                });

            migrationBuilder.CreateTable(
                name: "QuctionTests",
                columns: table => new
                {
                    QuctionTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChearId = table.Column<int>(type: "int", nullable: true),
                    ChearState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuctionTests", x => x.QuctionTestId);
                    table.ForeignKey(
                        name: "FK_QuctionTests_Chears_ChearId",
                        column: x => x.ChearId,
                        principalTable: "Chears",
                        principalColumn: "ChearId");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChearId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    AnotherCharacter = table.Column<int>(type: "int", nullable: true),
                    ChearPositionResult = table.Column<int>(type: "int", nullable: true),
                    ChearState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Results_Chears_ChearId",
                        column: x => x.ChearId,
                        principalTable: "Chears",
                        principalColumn: "ChearId");
                    table.ForeignKey(
                        name: "FK_Results_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuctionTests_ChearId",
                table: "QuctionTests",
                column: "ChearId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ChearId",
                table: "Results",
                column: "ChearId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_PatientId",
                table: "Results",
                column: "PatientId");
        }
    }
}
