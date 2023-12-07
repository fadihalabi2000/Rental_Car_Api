using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Car_DataAccess.Migrations
{
    public partial class AddFaild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ReturnDateTime",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDateTime",
                table: "FinancialTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "reservationStatus",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDateTime",
                table: "FinancialTransactions");

            migrationBuilder.DropColumn(
                name: "reservationStatus",
                table: "Bookings");

            migrationBuilder.AddColumn<double>(
                name: "AmountPaid",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDateTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
