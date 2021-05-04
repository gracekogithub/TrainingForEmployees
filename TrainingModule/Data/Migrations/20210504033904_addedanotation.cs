using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class addedanotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ManagerName",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ManagerFirstName",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerLastName",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fd81686-99f1-453e-8a7f-8f96e976a7e3", "0e466da3-25e7-4bd9-b278-d9b6924868ec", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93d84358-d9e2-4187-b604-7c51d57eb019", "a2d319b6-7174-4516-ba8f-9615ad4b8b59", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93d84358-d9e2-4187-b604-7c51d57eb019");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fd81686-99f1-453e-8a7f-8f96e976a7e3");

            migrationBuilder.DropColumn(
                name: "ManagerFirstName",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "ManagerLastName",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeLastName",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
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
    }
}
