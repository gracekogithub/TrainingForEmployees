using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class onetoManyrelationshipfortraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviewers_Employees_UserEmployeeId",
                table: "Reviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Reviewers_ReviewersReviewerId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_ReviewersReviewerId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ReviewersReviewerId",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "UserEmployeeId",
                table: "Reviewers",
                newName: "TrainingsTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviewers_UserEmployeeId",
                table: "Reviewers",
                newName: "IX_Reviewers_TrainingsTrainingId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Reviewers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialDetails",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialDetails", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_MaterialDetails_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDetails",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDetails", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_TrainingDetails_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviewers_EmployeeId",
                table: "Reviewers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviewers_Employees_EmployeeId",
                table: "Reviewers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviewers_Trainings_TrainingsTrainingId",
                table: "Reviewers",
                column: "TrainingsTrainingId",
                principalTable: "Trainings",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviewers_Employees_EmployeeId",
                table: "Reviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviewers_Trainings_TrainingsTrainingId",
                table: "Reviewers");

            migrationBuilder.DropTable(
                name: "MaterialDetails");

            migrationBuilder.DropTable(
                name: "TrainingDetails");

            migrationBuilder.DropIndex(
                name: "IX_Reviewers_EmployeeId",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Reviewers");

            migrationBuilder.RenameColumn(
                name: "TrainingsTrainingId",
                table: "Reviewers",
                newName: "UserEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviewers_TrainingsTrainingId",
                table: "Reviewers",
                newName: "IX_Reviewers_UserEmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "ReviewersReviewerId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ReviewersReviewerId",
                table: "Trainings",
                column: "ReviewersReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviewers_Employees_UserEmployeeId",
                table: "Reviewers",
                column: "UserEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Reviewers_ReviewersReviewerId",
                table: "Trainings",
                column: "ReviewersReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
