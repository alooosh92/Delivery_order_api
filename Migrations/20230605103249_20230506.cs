using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery_order.Migrations
{
    /// <inheritdoc />
    public partial class _20230506 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFood",
                table: "ShopTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFood",
                table: "ShopTypes");
        }
    }
}
