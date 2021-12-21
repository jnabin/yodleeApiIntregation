using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace YodleeIntegration.Infrastructure.Migrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YodleeActivityLogs");

            migrationBuilder.RenameColumn(
                name: "ExceptionMessage",
                table: "YodleeRequestLog",
                newName: "ReasonPhrase");

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "YodleeRequestLog",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "YodleeRequestLog");

            migrationBuilder.RenameColumn(
                name: "ReasonPhrase",
                table: "YodleeRequestLog",
                newName: "ExceptionMessage");

            migrationBuilder.CreateTable(
                name: "YodleeActivityLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionPerformed = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeActivityLogs", x => x.Id);
                });
        }
    }
}
