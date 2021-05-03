using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class dateTrial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "Tickets");
        }
    }
}
