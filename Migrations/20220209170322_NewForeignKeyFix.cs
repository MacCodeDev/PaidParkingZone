using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.Migrations
{
    public partial class NewForeignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonamenty_Klienci");

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "Abonamenty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Abonamenty_CustomersId",
                table: "Abonamenty",
                column: "CustomersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonamenty_Klienci_CustomersId",
                table: "Abonamenty",
                column: "CustomersId",
                principalTable: "Klienci",
                principalColumn: "CustomersId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonamenty_Klienci_CustomersId",
                table: "Abonamenty");

            migrationBuilder.DropIndex(
                name: "IX_Abonamenty_CustomersId",
                table: "Abonamenty");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "Abonamenty");

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
    }
}
