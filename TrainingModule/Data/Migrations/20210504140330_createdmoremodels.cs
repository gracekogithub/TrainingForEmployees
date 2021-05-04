using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class createdmoremodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerEmployees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "197e6c60-33d8-4137-be22-3bc481d2570c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c41baef-457f-44eb-9939-0a25fd01ce4e");

            migrationBuilder.DropColumn(
                name: "Reply",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFeedbacks",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFeedbacks", x => new { x.FeedbackId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeFeedbacks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeFeedbacks_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "FeedbackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagerFeedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerFeedbacks", x => new { x.FeedbackId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_ManagerFeedbacks_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "FeedbackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerFeedbacks_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7858376c-64ed-4b91-af39-f6b629efdf9c", "8012ee14-d2d9-410c-95a4-74a4886bea78", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fec9c180-53b6-4e5d-96cf-3f68cdd23836", "293d2e5b-1a48-40c6-8f38-6a52fb299d0d", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFeedbacks_EmployeeId",
                table: "EmployeeFeedbacks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerFeedbacks_ManagerId",
                table: "ManagerFeedbacks",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeFeedbacks");

            migrationBuilder.DropTable(
                name: "ManagerFeedbacks");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7858376c-64ed-4b91-af39-f6b629efdf9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec9c180-53b6-4e5d-96cf-3f68cdd23836");

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

            migrationBuilder.CreateTable(
                name: "ManagerEmployees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerEmployees", x => new { x.EmployeeId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_ManagerEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerEmployees_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "197e6c60-33d8-4137-be22-3bc481d2570c", "15bf3e61-8baf-4432-92c6-aad16e8b1b68", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c41baef-457f-44eb-9939-0a25fd01ce4e", "a3eae4a3-91a2-4013-b3ed-d9fdc760fe12", "Employee", "Employee" });

            migrationBuilder.CreateIndex(
                name: "IX_ManagerEmployees_ManagerId",
                table: "ManagerEmployees",
                column: "ManagerId");
        }
    }
}
