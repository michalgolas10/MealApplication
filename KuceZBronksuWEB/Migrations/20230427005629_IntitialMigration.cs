using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
	/// <inheritdoc />
	public partial class IntitialMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Recipes",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ShareAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
					DietLabels = table.Column<string>(type: "nvarchar(max)", nullable: true),
					HealthLabels = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Cautions = table.Column<string>(type: "nvarchar(max)", nullable: true),
					IngredientLines = table.Column<string>(type: "nvarchar(max)", nullable: true),
					RecipeSteps = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Calories = table.Column<double>(type: "float", nullable: false),
					CuisineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Servings = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Recipes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "FavouritesRecipes",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					RecipeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FavouritesRecipes", x => new { x.RecipeId, x.UserId });
					table.ForeignKey(
						name: "FK_FavouritesRecipes_Recipes_RecipeId",
						column: x => x.RecipeId,
						principalTable: "Recipes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_FavouritesRecipes_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_FavouritesRecipes_UserId",
				table: "FavouritesRecipes",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "FavouritesRecipes");

			migrationBuilder.DropTable(
				name: "Recipes");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}