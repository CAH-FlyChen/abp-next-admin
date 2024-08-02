using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zion.System.Migrations
{
    /// <inheritdoc />
    public partial class _2024080201 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteUniqueId",
                table: "App_System_Companies",
                newName: "DUId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DUId",
                table: "App_System_Companies",
                newName: "DeleteUniqueId");
        }
    }
}
