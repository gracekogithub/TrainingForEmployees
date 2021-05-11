using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class changedtoonetomanyrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewerTraining");

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
                name: "FK_Trainings_Reviewers_ReviewersReviewerId",
                table: "Trainings",
                column: "ReviewersReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Reviewers_ReviewersReviewerId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_ReviewersReviewerId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ReviewersReviewerId",
                table: "Trainings");

            migrationBuilder.CreateTable(
                name: "ReviewerTraining",
                columns: table => new
                {
                    ReviewersReviewerId = table.Column<int>(type: "int", nullable: false),
                    TrainingsTrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewerTraining", x => new { x.ReviewersReviewerId, x.TrainingsTrainingId });
                    table.ForeignKey(
                        name: "FK_ReviewerTraining_Reviewers_ReviewersReviewerId",
                        column: x => x.ReviewersReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "ReviewerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewerTraining_Trainings_TrainingsTrainingId",
                        column: x => x.TrainingsTrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewerTraining_TrainingsTrainingId",
                table: "ReviewerTraining",
                column: "TrainingsTrainingId");
        }
    }
}
