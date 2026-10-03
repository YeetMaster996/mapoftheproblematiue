using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapOfTheProblematque.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThreeLayerCascadeDropdown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudySubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudySubject_StudyClass_StudyClassId",
                        column: x => x.StudyClassId,
                        principalTable: "StudyClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyTopic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudySubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyTopic_StudySubject_StudySubjectId",
                        column: x => x.StudySubjectId,
                        principalTable: "StudySubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudySubject_StudyClassId",
                table: "StudySubject",
                column: "StudyClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTopic_StudySubjectId",
                table: "StudyTopic",
                column: "StudySubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyTopic");

            migrationBuilder.DropTable(
                name: "StudySubject");

            migrationBuilder.DropTable(
                name: "StudyClass");
        }
    }
}
