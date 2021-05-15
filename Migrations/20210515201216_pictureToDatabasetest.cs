using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class pictureToDatabasetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture2",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture3",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture2",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Picture3",
                table: "Tickets");
        }
    }
}
