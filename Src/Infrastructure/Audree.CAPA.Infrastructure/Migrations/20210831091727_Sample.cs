using Microsoft.EntityFrameworkCore.Migrations;

namespace Audree.CAPA.Infrastructure.Migrations
{
    public partial class Sample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student",
                newSchema: "Master");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                schema: "Master",
                table: "Student",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                schema: "Master",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                schema: "Master",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }
    }
}
