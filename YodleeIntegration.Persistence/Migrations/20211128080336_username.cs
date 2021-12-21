using Microsoft.EntityFrameworkCore.Migrations;

namespace YodleeIntegration.Infrastructure.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "YodleeConfigurations",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "AdminUsername",
                table: "YodleeConfigurations",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminUsername",
                table: "YodleeConfigurations");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "YodleeConfigurations",
                newName: "UserName");
        }
    }
}
