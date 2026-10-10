using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapOfTheProblematque.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCityIdAndName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "City",
                newName: "CityName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "City",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "City",
                newName: "Id");
        }
    }
}
