using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class manytomanyrelationshipcreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerTrainings_Managers_ManagerId",
                table: "ManagerTrainings");

            migrationBuilder.DropIndex(
                name: "IX_ManagerTrainings_ManagerId",
                table: "ManagerTrainings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93d84358-d9e2-4187-b604-7c51d57eb019");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fd81686-99f1-453e-8a7f-8f96e976a7e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "197e6c60-33d8-4137-be22-3bc481d2570c", "15bf3e61-8baf-4432-92c6-aad16e8b1b68", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c41baef-457f-44eb-9939-0a25fd01ce4e", "a3eae4a3-91a2-4013-b3ed-d9fdc760fe12", "Employee", "Employee" });

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerTrainings_Managers_TrainingId",
                table: "ManagerTrainings",
                column: "TrainingId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerTrainings_Managers_TrainingId",
                table: "ManagerTrainings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "197e6c60-33d8-4137-be22-3bc481d2570c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c41baef-457f-44eb-9939-0a25fd01ce4e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fd81686-99f1-453e-8a7f-8f96e976a7e3", "0e466da3-25e7-4bd9-b278-d9b6924868ec", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93d84358-d9e2-4187-b604-7c51d57eb019", "a2d319b6-7174-4516-ba8f-9615ad4b8b59", "Employee", "Employee" });

            migrationBuilder.CreateIndex(
                name: "IX_ManagerTrainings_ManagerId",
                table: "ManagerTrainings",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerTrainings_Managers_ManagerId",
                table: "ManagerTrainings",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
