using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infra.Data.Migrations
{
    public partial class NameTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                table: "USER");

            migrationBuilder.RenameTable(
                name: "USER",
                newName: "USERS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USERS",
                table: "USERS",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USERS",
                table: "USERS");

            migrationBuilder.RenameTable(
                name: "USERS",
                newName: "USER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                table: "USER",
                column: "ID");
        }
    }
}
