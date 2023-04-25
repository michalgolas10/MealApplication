using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
    /// <inheritdoc />
    public partial class FixForFavouritesRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritesRecipes_Recipes_RecipesId",
                table: "FavouritesRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouritesRecipes_Users_UsersId",
                table: "FavouritesRecipes");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "FavouritesRecipes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RecipesId",
                table: "FavouritesRecipes",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritesRecipes_UsersId",
                table: "FavouritesRecipes",
                newName: "IX_FavouritesRecipes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritesRecipes_Recipes_RecipeId",
                table: "FavouritesRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritesRecipes_Users_UserId",
                table: "FavouritesRecipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritesRecipes_Recipes_RecipeId",
                table: "FavouritesRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouritesRecipes_Users_UserId",
                table: "FavouritesRecipes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FavouritesRecipes",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "FavouritesRecipes",
                newName: "RecipesId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouritesRecipes_UserId",
                table: "FavouritesRecipes",
                newName: "IX_FavouritesRecipes_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritesRecipes_Recipes_RecipesId",
                table: "FavouritesRecipes",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritesRecipes_Users_UsersId",
                table: "FavouritesRecipes",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
