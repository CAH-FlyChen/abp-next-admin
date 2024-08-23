using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LY.MicroService.Applications.Single.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class _2024082302 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_SalesShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItem",
                newName: "SalesShoppingCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "SalesShoppingCartItems",
                newName: "IX_SalesShoppingCartItems_ShoppingCartId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuggest",
                table: "App_Product_Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesShoppingCartItems",
                table: "SalesShoppingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesShoppingCartItems_SalesShoppingCarts_ShoppingCartId",
                table: "SalesShoppingCartItems",
                column: "ShoppingCartId",
                principalTable: "SalesShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesShoppingCartItems_SalesShoppingCarts_ShoppingCartId",
                table: "SalesShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesShoppingCartItems",
                table: "SalesShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "IsSuggest",
                table: "App_Product_Products");

            migrationBuilder.RenameTable(
                name: "SalesShoppingCartItems",
                newName: "ShoppingCartItem");

            migrationBuilder.RenameIndex(
                name: "IX_SalesShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItem",
                newName: "IX_ShoppingCartItem_ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_SalesShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "SalesShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
