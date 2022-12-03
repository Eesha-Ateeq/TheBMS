using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBMS.Data.Migrations
{
    public partial class bakerymenuEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "bakerymenu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "bakerymenu");
        }
    }
}
