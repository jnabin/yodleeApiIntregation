using Microsoft.EntityFrameworkCore.Migrations;

namespace YodleeIntegration.Infrastructure.Migrations
{
    public partial class UpdateCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate_temp",
                table: "YodleeApiKeys",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "YodleeApiKeys",
                newName: "CreatedDate_temp");
        }
    }
}
