using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapOfTheProblematque.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Problem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problem_CountryId",
                table: "Problem",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Country_CountryId",
                table: "Problem",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Country_CountryId",
                table: "Problem");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Problem_CountryId",
                table: "Problem");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Problem");
        }
    }
}
