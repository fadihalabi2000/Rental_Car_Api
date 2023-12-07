using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Car_DataAccess.Migrations
{
    public partial class Add_denied_feld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total_Fund",
                table: "FinancialTransactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeniedEndDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total_Fund",
                table: "FinancialTransactions");

            migrationBuilder.DropColumn(
                name: "DeniedEndDate",
                table: "Customers");
        }
    }
}
