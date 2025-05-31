using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class changeGeneratedCodeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_GeneratedCode",
                table: "Products",
                column: "GeneratedCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_GeneratedCode",
                table: "Products");
        }
    }
}
