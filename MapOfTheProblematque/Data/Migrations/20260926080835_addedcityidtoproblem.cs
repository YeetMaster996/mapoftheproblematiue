using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapOfTheProblematque.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedcityidtoproblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Problem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problem_CityId",
                table: "Problem",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_City_CityId",
                table: "Problem",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_City_CityId",
                table: "Problem");

            migrationBuilder.DropIndex(
                name: "IX_Problem_CityId",
                table: "Problem");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Problem");
        }
    }
}
