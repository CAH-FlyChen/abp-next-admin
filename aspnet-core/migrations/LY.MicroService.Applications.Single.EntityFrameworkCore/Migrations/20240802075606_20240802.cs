using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LY.MicroService.Applications.Single.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class _20240802 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReginTypeCode",
                table: "App_System_Regions",
                newName: "RegionTypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionTypeCode",
                table: "App_System_Regions",
                newName: "ReginTypeCode");
        }
    }
}
