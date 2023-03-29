using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LargeImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbnailImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    THUMBNAILId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SMALLId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    REGULARId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LARGEId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LARGEId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    REGULARId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SMALLId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    THUMBNAILId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_Images_LargeImages_LARGEId1",
                        column: x => x.LARGEId1,
                        principalTable: "LargeImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_RegularImages_REGULARId",
                        column: x => x.REGULARId,
                        principalTable: "RegularImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_RegularImages_REGULARId1",
                        column: x => x.REGULARId1,
                        principalTable: "RegularImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_SmallImages_SMALLId",
                        column: x => x.SMALLId,
                        principalTable: "SmallImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_SmallImages_SMALLId1",
                        column: x => x.SMALLId1,
                        principalTable: "SmallImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ThumbnailImages_THUMBNAILId",
                        column: x => x.THUMBNAILId,
                        principalTable: "ThumbnailImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ThumbnailImages_THUMBNAILId1",
                        column: x => x.THUMBNAILId1,
                        principalTable: "ThumbnailImages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareAs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietLabels = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthLabels = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cautions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientLines = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeSteps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    CuisineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImagesId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Images_ImagesId1",
                        column: x => x.ImagesId1,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_LARGEId",
                table: "Images",
                column: "LARGEId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LARGEId1",
                table: "Images",
                column: "LARGEId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_REGULARId",
                table: "Images",
                column: "REGULARId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_REGULARId1",
                table: "Images",
                column: "REGULARId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_SMALLId",
                table: "Images",
                column: "SMALLId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_SMALLId1",
                table: "Images",
                column: "SMALLId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_THUMBNAILId",
                table: "Images",
                column: "THUMBNAILId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_THUMBNAILId1",
                table: "Images",
                column: "THUMBNAILId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ImagesId",
                table: "Recipes",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ImagesId1",
                table: "Recipes",
                column: "ImagesId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId1",
                table: "Recipes",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LargeImages");

            migrationBuilder.DropTable(
                name: "RegularImages");

            migrationBuilder.DropTable(
                name: "SmallImages");

            migrationBuilder.DropTable(
                name: "ThumbnailImages");
        }
    }
}
