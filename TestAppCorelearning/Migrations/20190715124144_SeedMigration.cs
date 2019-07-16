using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAppCorelearning.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Deptartment", "Email", "Name" },
                values: new object[] { 1, 3, "kalai.nemesis@gmail.com", "kalai" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
