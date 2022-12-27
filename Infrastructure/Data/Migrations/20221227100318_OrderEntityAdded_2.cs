using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class OrderEntityAdded_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemOrdered_ProductUrl",
                table: "OrderItems",
                newName: "ItemOrdered_PictureUrl");

            migrationBuilder.AlterColumn<long>(
                name: "OrderDate",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(18,2");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "DeliveryMethods",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(18,2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems",
                newName: "ItemOrdered_ProductUrl");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderDate",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,2",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "DeliveryMethods",
                type: "decimal(18,2",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(18,2)");
        }
    }
}
