using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class photoUpload3Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath2",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath3",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath2",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PhotoPath3",
                table: "Tickets");
        }
    }
}
