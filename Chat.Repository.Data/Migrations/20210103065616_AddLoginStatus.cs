using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Repository.Data.Migrations
{
    public partial class AddLoginStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LoginStatus",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginStatus",
                table: "Users");
        }
    }
}
