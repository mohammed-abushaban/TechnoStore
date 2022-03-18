using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoStore.Data.Migrations
{
    public partial class EdiDddddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Warehouses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_UserId",
                table: "Warehouses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_UserId",
                table: "Warehouses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_UserId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_UserId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Warehouses");
        }
    }
}
