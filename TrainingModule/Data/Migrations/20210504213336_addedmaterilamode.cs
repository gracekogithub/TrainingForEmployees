using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class addedmaterilamode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12924f96-00df-4cde-b42c-d9dbc40ca883");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b467d830-9b3d-43b0-ab3d-62ebd03e189d");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Matrials",
                columns: table => new
                {
                    MatrialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matrials", x => x.MatrialId);
                    table.ForeignKey(
                        name: "FK_Matrials_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19e86c6a-1ecb-4ccd-ad66-a279f08163af", "7a485860-f7ab-4856-93fc-00f131955e86", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a20df560-88f3-42f0-8b6f-8e90aa265eb6", "6cc59d8e-8ad1-4aca-8583-310c99f43ef8", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Matrials_TrainingId",
                table: "Matrials",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matrials");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19e86c6a-1ecb-4ccd-ad66-a279f08163af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a20df560-88f3-42f0-8b6f-8e90aa265eb6");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b467d830-9b3d-43b0-ab3d-62ebd03e189d", "3ca763d6-6deb-4e37-ab5d-b90973305f60", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12924f96-00df-4cde-b42c-d9dbc40ca883", "057652e5-0988-4f9e-859e-a80bb88ca4c2", "Employee", "EMPLOYEE" });
        }
    }
}
