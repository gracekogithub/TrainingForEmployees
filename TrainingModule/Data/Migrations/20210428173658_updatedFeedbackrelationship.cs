using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Data.Migrations
{
    public partial class updatedFeedbackrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff743708-2a0a-4e2a-9f47-d0a5a1f99553");

            migrationBuilder.DeleteData(
                table: "PostUpdates",
                keyColumn: "PostUpdateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostUpdates",
                keyColumn: "PostUpdateId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "PostUpdates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b27bf99d-56de-4b20-985d-556e2e566511", "4a332f22-4e3b-455a-9542-5215ef7fe65a", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8201ef27-5f50-40b5-8b15-f094d7140779", "01d0a653-818e-4a39-96f2-146dc9f64b0b", "Employee", "Employee" });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_IdentityUserId",
                table: "Managers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_EmployeeId",
                table: "Feedbacks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ManagerId",
                table: "Feedbacks",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Employees_EmployeeId",
                table: "Feedbacks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Managers_ManagerId",
                table: "Feedbacks",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_IdentityUserId",
                table: "Managers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Employees_EmployeeId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Managers_ManagerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_IdentityUserId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_IdentityUserId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_EmployeeId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ManagerId",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8201ef27-5f50-40b5-8b15-f094d7140779");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b27bf99d-56de-4b20-985d-556e2e566511");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "PostUpdates");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff743708-2a0a-4e2a-9f47-d0a5a1f99553", "4c549778-ef01-4f8f-afeb-3cc987cf3d2c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "PostUpdates",
                columns: new[] { "PostUpdateId", "Daily", "DailyContent", "DailyCreated", "Weekly", "WeeklyContent", "WeeklyCreated" },
                values: new object[] { 1, "Reminder", "We have a Cap inspection", new DateTime(2021, 4, 27, 11, 17, 7, 932, DateTimeKind.Local).AddTicks(6926), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PostUpdates",
                columns: new[] { "PostUpdateId", "Daily", "DailyContent", "DailyCreated", "Weekly", "WeeklyContent", "WeeklyCreated" },
                values: new object[] { 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly Hightlight", "Will be posted", new DateTime(2021, 4, 27, 11, 17, 7, 939, DateTimeKind.Local).AddTicks(6720) });
        }
    }
}
