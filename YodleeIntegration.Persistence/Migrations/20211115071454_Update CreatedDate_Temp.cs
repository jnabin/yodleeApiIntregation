using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace YodleeIntegration.Infrastructure.Migrations
{
    public partial class UpdateCreatedDate_Temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "YodleeApiKeys");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate_temp",
                table: "YodleeApiKeys",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate_temp",
                table: "YodleeApiKeys");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "YodleeApiKeys",
                type: "text",
                nullable: true);
        }
    }
}
