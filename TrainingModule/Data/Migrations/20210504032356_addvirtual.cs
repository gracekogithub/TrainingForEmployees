using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class addvirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostUpdates_AspNetUsers_IdentityUserId",
                table: "PostUpdates");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropIndex(
                name: "IX_PostUpdates_IdentityUserId",
                table: "PostUpdates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd956ae9-aea1-42f5-a626-33bb5bd56671");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd6d7adc-11fb-478b-90f5-5cd13720b601");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "PostUpdates");

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

            migrationBuilder.CreateTable(
                name: "ManagerTrainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerTrainings", x => new { x.TrainingId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_ManagerTrainings_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagerUpdates",
                columns: table => new
                {
                    UpdateId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerUpdates", x => new { x.UpdateId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_ManagerUpdates_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerUpdates_PostUpdates_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "PostUpdates",
                        principalColumn: "UpdateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b3b9e81-c9c4-438c-9965-61afc32a10f5", "b0c335ab-66c5-4cb5-b182-7d22d0139889", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "213b711c-4f4d-4dc6-ba45-51a7ec225a6a", "02faf174-eee0-43e1-9b09-7deeac418066", "Employee", "Employee" });

            migrationBuilder.CreateIndex(
                name: "IX_ManagerEmployees_ManagerId",
                table: "ManagerEmployees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerTrainings_ManagerId",
                table: "ManagerTrainings",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerUpdates_ManagerId",
                table: "ManagerUpdates",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerEmployees");

            migrationBuilder.DropTable(
                name: "ManagerTrainings");

            migrationBuilder.DropTable(
                name: "ManagerUpdates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "213b711c-4f4d-4dc6-ba45-51a7ec225a6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3b9e81-c9c4-438c-9965-61afc32a10f5");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "PostUpdates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => new { x.EmployeeId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_Comments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => new { x.TrainingId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_Materials_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    UpdateId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => new { x.UpdateId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_Post_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_PostUpdates_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "PostUpdates",
                        principalColumn: "UpdateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd6d7adc-11fb-478b-90f5-5cd13720b601", "49de69d2-ddd0-449f-828d-8d8bc91c502b", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd956ae9-aea1-42f5-a626-33bb5bd56671", "2f5e4a3f-b24e-4215-944f-cf30078b63d9", "Employee", "Employee" });

            migrationBuilder.CreateIndex(
                name: "IX_PostUpdates_IdentityUserId",
                table: "PostUpdates",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ManagerId",
                table: "Comments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ManagerId",
                table: "Materials",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ManagerId",
                table: "Post",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostUpdates_AspNetUsers_IdentityUserId",
                table: "PostUpdates",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
