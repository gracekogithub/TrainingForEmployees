using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Data.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe1e8d1-28ab-4cc0-801b-39f9dcc0e0ce");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfe1e8d1-28ab-4cc0-801b-39f9dcc0e0ce", "6774d469-a9f2-46d3-939a-f484395fa61c", "Admin", "ADMIN" });
        }
    }
}
