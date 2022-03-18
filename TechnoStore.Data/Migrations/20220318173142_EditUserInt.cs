using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoStore.Data.Migrations
{
    public partial class EditUserInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_UserId1",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_UserId1",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Warehouses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Warehouses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_UserId1",
                table: "Warehouses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_UserId1",
                table: "Warehouses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
