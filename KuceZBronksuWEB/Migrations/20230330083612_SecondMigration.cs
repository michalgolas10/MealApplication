using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_LargeImages_LARGEId1",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_RegularImages_REGULARId1",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_SmallImages_SMALLId1",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_ThumbnailImages_THUMBNAILId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_LARGEId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_REGULARId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_SMALLId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_THUMBNAILId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "LARGEId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "REGULARId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "SMALLId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "THUMBNAILId1",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LARGEId1",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "REGULARId1",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SMALLId1",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "THUMBNAILId1",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_LARGEId1",
                table: "Images",
                column: "LARGEId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_REGULARId1",
                table: "Images",
                column: "REGULARId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_SMALLId1",
                table: "Images",
                column: "SMALLId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_THUMBNAILId1",
                table: "Images",
                column: "THUMBNAILId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_LargeImages_LARGEId1",
                table: "Images",
                column: "LARGEId1",
                principalTable: "LargeImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_RegularImages_REGULARId1",
                table: "Images",
                column: "REGULARId1",
                principalTable: "RegularImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_SmallImages_SMALLId1",
                table: "Images",
                column: "SMALLId1",
                principalTable: "SmallImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ThumbnailImages_THUMBNAILId1",
                table: "Images",
                column: "THUMBNAILId1",
                principalTable: "ThumbnailImages",
                principalColumn: "Id");
        }
    }
}
