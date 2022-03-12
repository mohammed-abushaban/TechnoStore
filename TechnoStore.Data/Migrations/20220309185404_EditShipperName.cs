using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoStore.Data.Migrations
{
    public partial class EditShipperName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShipperDbEntity_ShipperId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShipperDbEntity_ShipperId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipperDbEntity",
                table: "ShipperDbEntity");

            migrationBuilder.RenameTable(
                name: "ShipperDbEntity",
                newName: "Shippers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shippers",
                table: "Shippers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shippers_ShipperId",
                table: "AspNetUsers",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippers_ShipperId",
                table: "Orders",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shippers_ShipperId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippers_ShipperId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shippers",
                table: "Shippers");

            migrationBuilder.RenameTable(
                name: "Shippers",
                newName: "ShipperDbEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipperDbEntity",
                table: "ShipperDbEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShipperDbEntity_ShipperId",
                table: "AspNetUsers",
                column: "ShipperId",
                principalTable: "ShipperDbEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShipperDbEntity_ShipperId",
                table: "Orders",
                column: "ShipperId",
                principalTable: "ShipperDbEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
