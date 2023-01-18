using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infra.Data.Migrations
{
    public partial class Refactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ID",
                table: "USER");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USER",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                table: "USER",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                table: "USER");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "USER",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "ID",
                table: "USER",
                column: "Id");
        }
    }
}
