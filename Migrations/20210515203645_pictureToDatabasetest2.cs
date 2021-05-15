using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class pictureToDatabasetest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PhotoPath2",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PhotoPath3",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath1",
                table: "Tickets",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath2",
                table: "Tickets",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath3",
                table: "Tickets",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
