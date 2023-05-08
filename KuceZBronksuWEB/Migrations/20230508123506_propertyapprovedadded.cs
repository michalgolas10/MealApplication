using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuceZBronksuWEB.Migrations
{
    /// <inheritdoc />
    public partial class propertyapprovedadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Recipes");
        }
    }
}
