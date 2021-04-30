using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Data.Migrations
{
    public partial class addedPublicInAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2a99868-7e76-4328-b241-d23acf0bea0a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfe1e8d1-28ab-4cc0-801b-39f9dcc0e0ce", "6774d469-a9f2-46d3-939a-f484395fa61c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe1e8d1-28ab-4cc0-801b-39f9dcc0e0ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2a99868-7e76-4328-b241-d23acf0bea0a", "f2cfcc3f-46a5-4621-b0af-e30873c57c64", "Admin", "ADMIN" });
        }
    }
}
