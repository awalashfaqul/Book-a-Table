using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_a_Table.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    BoardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardNum = table.Column<int>(type: "int", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    BoardType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustFirstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustLastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustHousenum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustZipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustID);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemID);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardID = table.Column<int>(type: "int", nullable: false),
                    CustID = table.Column<int>(type: "int", nullable: false),
                    CustomerCustID = table.Column<int>(type: "int", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalGuests = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Boards_BoardID",
                        column: x => x.BoardID,
                        principalTable: "Boards",
                        principalColumn: "BoardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerCustID",
                        column: x => x.CustomerCustID,
                        principalTable: "Customers",
                        principalColumn: "CustID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BoardID",
                table: "Bookings",
                column: "BoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerCustID",
                table: "Bookings",
                column: "CustomerCustID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
