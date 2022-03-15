using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoStore.Data.Migrations
{
    public partial class DeletRela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shippers_ShipperId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippers_ShipperId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Products_ProductId",
                table: "ProductQuantities");

            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipperId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductQuantities");

            migrationBuilder.DropColumn(
                name: "ShipperId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShipperId",
                table: "AspNetUsers",
                newName: "CityDbEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ShipperId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CityDbEntityId");

            migrationBuilder.AddColumn<int>(
                name: "CityDbEntityId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longtude = table.Column<double>(type: "float", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "warehouseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_warehouseProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warehouseProducts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CityDbEntityId",
                table: "Suppliers",
                column: "CityDbEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouseProducts_ProductId",
                table: "warehouseProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouseProducts_WarehouseId",
                table: "warehouseProducts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CityId",
                table: "Warehouses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_UserId1",
                table: "Warehouses",
                column: "UserId1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityDbEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Cities_CityDbEntityId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "warehouseProducts");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CityDbEntityId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CityDbEntityId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "CityDbEntityId",
                table: "AspNetUsers",
                newName: "ShipperId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CityDbEntityId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ShipperId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShipperId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperId",
                table: "Orders",
                column: "ShipperId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Products_ProductId",
                table: "ProductQuantities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
