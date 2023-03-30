using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigrationCorretingImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Images_ImagesId1",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ImagesId1",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ImagesId1",
                table: "Recipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagesId1",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ImagesId1",
                table: "Recipes",
                column: "ImagesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Images_ImagesId1",
                table: "Recipes",
                column: "ImagesId1",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
