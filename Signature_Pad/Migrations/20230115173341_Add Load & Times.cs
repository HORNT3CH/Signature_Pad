using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Signature_Pad.Migrations
{
    public partial class AddLoadTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualFinish",
                table: "Signature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualStart",
                table: "Signature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LoadNbr",
                table: "Signature",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualFinish",
                table: "Signature");

            migrationBuilder.DropColumn(
                name: "ActualStart",
                table: "Signature");

            migrationBuilder.DropColumn(
                name: "LoadNbr",
                table: "Signature");
        }
    }
}
