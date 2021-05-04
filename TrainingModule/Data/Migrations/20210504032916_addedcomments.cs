using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class addedcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "213b711c-4f4d-4dc6-ba45-51a7ec225a6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3b9e81-c9c4-438c-9965-61afc32a10f5");

            migrationBuilder.AddColumn<string>(
                name: "Reply",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07140eaf-7b00-4cbc-8cd8-78dea19168ad", "afb3646d-aa66-4228-87a9-4a3673a90472", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e41afd8-5930-4b5a-b497-9addcb65eb9e", "63f740e6-c6dd-4cbe-b42a-a68fc44891c8", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07140eaf-7b00-4cbc-8cd8-78dea19168ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e41afd8-5930-4b5a-b497-9addcb65eb9e");

            migrationBuilder.DropColumn(
                name: "Reply",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b3b9e81-c9c4-438c-9965-61afc32a10f5", "b0c335ab-66c5-4cb5-b182-7d22d0139889", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "213b711c-4f4d-4dc6-ba45-51a7ec225a6a", "02faf174-eee0-43e1-9b09-7deeac418066", "Employee", "Employee" });
        }
    }
}
