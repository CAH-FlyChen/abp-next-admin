using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LY.MicroService.Applications.Single.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class _2024082801 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificationTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Discriminator = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationTemplate_App_Product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "App_Product_Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecificationTemplate_App_Product_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "App_Product_Products",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpecificationGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategorySpecTemplateId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationGroup_SpecificationTemplate_CategorySpecTemplat~",
                        column: x => x.CategorySpecTemplateId,
                        principalTable: "SpecificationTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpecificationGroupItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SpecificationGroupId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Options = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationGroupItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationGroupItem_SpecificationGroup_SpecificationGroup~",
                        column: x => x.SpecificationGroupId,
                        principalTable: "SpecificationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationGroup_CategorySpecTemplateId",
                table: "SpecificationGroup",
                column: "CategorySpecTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationGroupItem_SpecificationGroupId",
                table: "SpecificationGroupItem",
                column: "SpecificationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationTemplate_CategoryId",
                table: "SpecificationTemplate",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationTemplate_ProductId",
                table: "SpecificationTemplate",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificationGroupItem");

            migrationBuilder.DropTable(
                name: "SpecificationGroup");

            migrationBuilder.DropTable(
                name: "SpecificationTemplate");
        }
    }
}
