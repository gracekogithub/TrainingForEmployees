using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class migragain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewerTraining_Reviewers_ReviewerId",
                table: "ReviewerTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewerTraining_Trainings_TrainingId",
                table: "ReviewerTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewerTraining",
                table: "ReviewerTraining");

            migrationBuilder.RenameTable(
                name: "ReviewerTraining",
                newName: "ReviewerTrainings");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewerTraining_ReviewerId",
                table: "ReviewerTrainings",
                newName: "IX_ReviewerTrainings_ReviewerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewerTrainings",
                table: "ReviewerTrainings",
                columns: new[] { "TrainingId", "ReviewerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewerTrainings_Reviewers_ReviewerId",
                table: "ReviewerTrainings",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewerTrainings_Trainings_TrainingId",
                table: "ReviewerTrainings",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewerTrainings_Reviewers_ReviewerId",
                table: "ReviewerTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewerTrainings_Trainings_TrainingId",
                table: "ReviewerTrainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewerTrainings",
                table: "ReviewerTrainings");

            migrationBuilder.RenameTable(
                name: "ReviewerTrainings",
                newName: "ReviewerTraining");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewerTrainings_ReviewerId",
                table: "ReviewerTraining",
                newName: "IX_ReviewerTraining_ReviewerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewerTraining",
                table: "ReviewerTraining",
                columns: new[] { "TrainingId", "ReviewerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewerTraining_Reviewers_ReviewerId",
                table: "ReviewerTraining",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewerTraining_Trainings_TrainingId",
                table: "ReviewerTraining",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
