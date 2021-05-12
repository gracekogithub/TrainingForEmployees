using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class editedmaterialmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "PdfName",
                table: "Materials",
                newName: "TrainingFormat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainingFormat",
                table: "Materials",
                newName: "PdfName");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
