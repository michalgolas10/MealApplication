using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRecipeTableImagechangedtoimageurlstring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Images_ImagesId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "LargeImages");

            migrationBuilder.DropTable(
                name: "RegularImages");

            migrationBuilder.DropTable(
                name: "SmallImages");

            migrationBuilder.DropTable(
                name: "ThumbnailImages");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ImagesId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "ImagesId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LargeImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LargeImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegularImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmallImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThumbnailImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbnailImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LARGEId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    REGULARId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SMALLId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    THUMBNAILId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_LargeImages_LARGEId",
                        column: x => x.LARGEId,
                        principalTable: "LargeImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_RegularImages_REGULARId",
                        column: x => x.REGULARId,
                        principalTable: "RegularImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_SmallImages_SMALLId",
                        column: x => x.SMALLId,
                        principalTable: "SmallImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ThumbnailImages_THUMBNAILId",
                        column: x => x.THUMBNAILId,
                        principalTable: "ThumbnailImages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ImagesId",
                table: "Recipes",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LARGEId",
                table: "Images",
                column: "LARGEId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_REGULARId",
                table: "Images",
                column: "REGULARId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_SMALLId",
                table: "Images",
                column: "SMALLId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_THUMBNAILId",
                table: "Images",
                column: "THUMBNAILId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Images_ImagesId",
                table: "Recipes",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
