using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class changednames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerUpdates_PostUpdates_UpdateId",
                table: "ManagerUpdates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostUpdates",
                table: "PostUpdates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7858376c-64ed-4b91-af39-f6b629efdf9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec9c180-53b6-4e5d-96cf-3f68cdd23836");

            migrationBuilder.RenameTable(
                name: "PostUpdates",
                newName: "Updates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Updates",
                table: "Updates",
                column: "UpdateId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b467d830-9b3d-43b0-ab3d-62ebd03e189d", "3ca763d6-6deb-4e37-ab5d-b90973305f60", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12924f96-00df-4cde-b42c-d9dbc40ca883", "057652e5-0988-4f9e-859e-a80bb88ca4c2", "Employee", "EMPLOYEE" });

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerUpdates_Updates_UpdateId",
                table: "ManagerUpdates",
                column: "UpdateId",
                principalTable: "Updates",
                principalColumn: "UpdateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerUpdates_Updates_UpdateId",
                table: "ManagerUpdates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Updates",
                table: "Updates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12924f96-00df-4cde-b42c-d9dbc40ca883");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b467d830-9b3d-43b0-ab3d-62ebd03e189d");

            migrationBuilder.RenameTable(
                name: "Updates",
                newName: "PostUpdates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostUpdates",
                table: "PostUpdates",
                column: "UpdateId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7858376c-64ed-4b91-af39-f6b629efdf9c", "8012ee14-d2d9-410c-95a4-74a4886bea78", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fec9c180-53b6-4e5d-96cf-3f68cdd23836", "293d2e5b-1a48-40c6-8f38-6a52fb299d0d", "Employee", "EMPLOYEE" });

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerUpdates_PostUpdates_UpdateId",
                table: "ManagerUpdates",
                column: "UpdateId",
                principalTable: "PostUpdates",
                principalColumn: "UpdateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
