using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalmornSRV.Service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "L_FileUpload",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    macAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L_FileUpload", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "M_Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isPreOrder = table.Column<bool>(type: "bit", nullable: true),
                    isUseStock = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    preStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    qtyShippingPriceCeiling = table.Column<int>(type: "int", nullable: false),
                    shippintPriceRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    unitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updateBy = table.Column<int>(type: "int", nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "M_Product_Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fileId = table.Column<long>(type: "bigint", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Product_Image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStocks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStocks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "S_Role",
                columns: table => new
                {
                    role = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_Role", x => x.role);
                });

            migrationBuilder.CreateTable(
                name: "S_RoleMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    role = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_RoleMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    displayName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    updateBy = table.Column<int>(type: "int", nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "T_Order_H",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    createBy = table.Column<int>(type: "int", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    isPay = table.Column<bool>(type: "bit", nullable: false),
                    isShipping = table.Column<bool>(type: "bit", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    province = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    shippingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    tel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    totalProductPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    updateBy = table.Column<int>(type: "int", nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    zipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Order_H", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "T_PaymentNotification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fileUpload = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    orderCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PaymentNotification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "T_Order_D",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order_Hid = table.Column<int>(type: "int", nullable: true),
                    hId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Order_D", x => x.id);
                    table.ForeignKey(
                        name: "FK_T_Order_D_T_Order_H_Order_Hid",
                        column: x => x.Order_Hid,
                        principalTable: "T_Order_H",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Order_D_Order_Hid",
                table: "T_Order_D",
                column: "Order_Hid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "L_FileUpload");

            migrationBuilder.DropTable(
                name: "M_Product");

            migrationBuilder.DropTable(
                name: "M_Product_Image");

            migrationBuilder.DropTable(
                name: "ProductStocks");

            migrationBuilder.DropTable(
                name: "S_Role");

            migrationBuilder.DropTable(
                name: "S_RoleMapping");

            migrationBuilder.DropTable(
                name: "S_User");

            migrationBuilder.DropTable(
                name: "T_Order_D");

            migrationBuilder.DropTable(
                name: "T_PaymentNotification");

            migrationBuilder.DropTable(
                name: "T_Order_H");
        }
    }
}
