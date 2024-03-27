using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class Init01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdultRate",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "ChildRate",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "DoubleRate",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "ExceptionCase",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "NoChild",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "NoExtraAdult",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "SingleEqualDouble",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "SingleRate",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "TripleRate",
                table: "HotelRooms");

            migrationBuilder.CreateTable(
                name: "RoomDateRanges",
                columns: table => new
                {
                    DateRangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SingleRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DoubleRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TripleRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdultRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SingleEqualDouble = table.Column<bool>(type: "bit", nullable: false),
                    ExceptionCase = table.Column<bool>(type: "bit", nullable: false),
                    NoExtraAdult = table.Column<bool>(type: "bit", nullable: false),
                    NoChild = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDateRanges", x => x.DateRangeId);
                    table.ForeignKey(
                        name: "FK_RoomDateRanges_HotelRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomDateRanges_RoomId",
                table: "RoomDateRanges",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomDateRanges");

            migrationBuilder.AddColumn<decimal>(
                name: "AdultRate",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ChildRate",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "HotelRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "HotelRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "DoubleRate",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "ExceptionCase",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NoChild",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NoExtraAdult",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SingleEqualDouble",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SingleRate",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TripleRate",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
