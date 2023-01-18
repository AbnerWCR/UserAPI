using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infra.Data.Migrations
{
    public partial class Refactor2_IgnorePasswordText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password_PasswordText",
                table: "USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password_PasswordText",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
