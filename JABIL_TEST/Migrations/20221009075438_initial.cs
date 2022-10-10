using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JABIL_TEST.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    PKBuilding = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUser = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.PKBuilding);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PKCustomers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Prefix = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FKBuilding = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUser = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PKCustomers);
                    table.ForeignKey(
                        name: "FK_Customers_Buildings",
                        column: x => x.FKBuilding,
                        principalTable: "Buildings",
                        principalColumn: "PKBuilding");
                });

            migrationBuilder.CreateTable(
                name: "PartNumbers",
                columns: table => new
                {
                    PKPartNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FKCustomer = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUser = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartNumbers", x => x.PKPartNumber);
                    table.ForeignKey(
                        name: "FK_PartNumbers_Customers",
                        column: x => x.FKCustomer,
                        principalTable: "Customers",
                        principalColumn: "PKCustomers");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FKBuilding",
                table: "Customers",
                column: "FKBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_PartNumbers_FKCustomer",
                table: "PartNumbers",
                column: "FKCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartNumbers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
