using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zion.System.Migrations
{
    /// <inheritdoc />
    public partial class _2024080203 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParentCode",
                table: "App_System_Regions",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "App_System_Regions",
                keyColumn: "ParentCode",
                keyValue: null,
                column: "ParentCode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ParentCode",
                table: "App_System_Regions",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
