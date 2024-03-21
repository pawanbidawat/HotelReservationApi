using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelDetails",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockedChildRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDetails", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingleRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DoubleRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TripleRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdultRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChildRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SingleEqualDouble = table.Column<bool>(type: "bit", nullable: false),
                    ExceptionCase = table.Column<bool>(type: "bit", nullable: false),
                    NoExtraAdult = table.Column<bool>(type: "bit", nullable: false),
                    NoChild = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_HotelRooms_HotelDetails_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelDetails",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlackoutDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackoutDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlackoutDate_HotelRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlackoutDate_RoomId",
                table: "BlackoutDate",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelId",
                table: "HotelRooms",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlackoutDate");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "HotelDetails");
        }
    }
}
