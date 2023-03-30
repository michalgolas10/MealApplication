using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
    /// <inheritdoc />
    public partial class TryingToAddFavRecipeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId2",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId2",
                table: "Recipes",
                column: "UserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId2",
                table: "Recipes",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId2",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserId2",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Recipes");
        }
    }
}
