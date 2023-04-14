using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    foodItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    foodItemName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.foodItem);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderMasters",
                columns: table => new
                {
                    orderMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orderNumber = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    pMethod = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    gTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMasters", x => x.orderMasterId);
                    table.ForeignKey(
                        name: "FK_OrderMasters_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    orderDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orderMasterId = table.Column<long>(type: "bigint", nullable: false),
                    foodItemId = table.Column<int>(type: "int", nullable: false),
                    foodItemPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.orderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_FoodItems_foodItemId",
                        column: x => x.foodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "foodItem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderMasters_orderMasterId",
                        column: x => x.orderMasterId,
                        principalTable: "OrderMasters",
                        principalColumn: "orderMasterId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_foodItemId",
                table: "OrderDetails",
                column: "foodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderMasterId",
                table: "OrderDetails",
                column: "orderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_customerId",
                table: "OrderMasters",
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "OrderMasters");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
