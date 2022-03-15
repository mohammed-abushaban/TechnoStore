using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoStore.Data.Migrations
{
    public partial class Editssd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityDbEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Cities_CityDbEntityId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CityDbEntityId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityDbEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityDbEntityId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityDbEntityId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityDbEntityId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Suppliers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityDbEntityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CityDbEntityId",
                table: "Suppliers",
                column: "CityDbEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityDbEntityId",
                table: "AspNetUsers",
                column: "CityDbEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityDbEntityId",
                table: "AspNetUsers",
                column: "CityDbEntityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Cities_CityDbEntityId",
                table: "Suppliers",
                column: "CityDbEntityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
