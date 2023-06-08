using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery_order.Migrations
{
    /// <inheritdoc />
    public partial class _202305061 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlIcon",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlIcon",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Shop");
        }
    }
}
