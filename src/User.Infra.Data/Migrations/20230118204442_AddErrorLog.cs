using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infra.Data.Migrations
{
    public partial class AddErrorLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ERRORS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    MESSAGE = table.Column<string>(type: "varchar(300)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERRORS", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ERRORS");
        }
    }
}
