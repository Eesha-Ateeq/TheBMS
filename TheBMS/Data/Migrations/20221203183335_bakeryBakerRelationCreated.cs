using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBMS.Data.Migrations
{
    public partial class bakeryBakerRelationCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BakerID",
                table: "bakerymenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bakerymenu_BakerID",
                table: "bakerymenu",
                column: "BakerID");

            migrationBuilder.AddForeignKey(
                name: "FK_bakerymenu_Baker_BakerID",
                table: "bakerymenu",
                column: "BakerID",
                principalTable: "Baker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bakerymenu_Baker_BakerID",
                table: "bakerymenu");

            migrationBuilder.DropIndex(
                name: "IX_bakerymenu_BakerID",
                table: "bakerymenu");

            migrationBuilder.DropColumn(
                name: "BakerID",
                table: "bakerymenu");
        }
    }
}
