using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapOfTheProblematque.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTypeNameToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Problem",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProblemType",
                table: "Problem",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Problem",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Problem",
                newName: "ProblemType");
        }
    }
}
