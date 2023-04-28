using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class ModifyShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopipingCardItems_Movies_MovieId",
                table: "ShopipingCardItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopipingCardItems",
                table: "ShopipingCardItems");

            migrationBuilder.RenameTable(
                name: "ShopipingCardItems",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ShoppingCardItem",
                table: "ShoppingCartItems",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopipingCardItems_MovieId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "ShopipingCardItems");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShopipingCardItems",
                newName: "ShoppingCardItem");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_MovieId",
                table: "ShopipingCardItems",
                newName: "IX_ShopipingCardItems_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopipingCardItems",
                table: "ShopipingCardItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopipingCardItems_Movies_MovieId",
                table: "ShopipingCardItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
