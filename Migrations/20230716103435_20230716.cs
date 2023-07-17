using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery_order.Migrations
{
    /// <inheritdoc />
    public partial class _20230716 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fireBaseToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fireBaseToken",
                table: "AspNetUsers");
        }
    }
}
