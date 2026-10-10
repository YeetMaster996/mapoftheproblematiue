using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapOfTheProblematque.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCountryFromProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Country_CountryId",
                table: "Problem");

            migrationBuilder.DropIndex(
                name: "IX_Problem_CountryId",
                table: "Problem");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Problem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Problem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Problem_CountryId",
                table: "Problem",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Country_CountryId",
                table: "Problem",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
