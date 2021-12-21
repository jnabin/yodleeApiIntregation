using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace YodleeIntegration.Infrastructure.Migrations
{
    public partial class AddedCreatedAtinthetoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "YodleeAuthTokens",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "YodleeAuthTokens");
        }
    }
}
