using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.Migrations
{
    public partial class CustomersFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Abonamenty");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Abonamenty");

            migrationBuilder.AddColumn<int>(
                name: "Paid",
                table: "Abonamenty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.CustomersId);
                });

            migrationBuilder.CreateTable(
                name: "Abonamenty_Klienci",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonamenty_Klienci", x => new { x.SubscriptionId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_Abonamenty_Klienci_Abonamenty_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Abonamenty",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonamenty_Klienci_Klienci_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Klienci",
                        principalColumn: "CustomersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonamenty_Klienci_CustomersId",
                table: "Abonamenty_Klienci",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonamenty_Klienci");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Abonamenty");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Abonamenty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Abonamenty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
