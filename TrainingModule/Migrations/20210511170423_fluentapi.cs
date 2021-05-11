using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingModule.Migrations
{
    public partial class fluentapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ReviewerTrainings");

            migrationBuilder.DropTable(
                name: "TrainingDetail");

            migrationBuilder.DropTable(
                name: "TrainingFiles");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reviewers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdfName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

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
                name: "IX_Trainings_MaterialId",
                table: "Trainings",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewers_UserId",
                table: "Reviewers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewerTraining_TrainingsTrainingId",
                table: "ReviewerTraining",
                column: "TrainingsTrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviewers_Users_UserId",
                table: "Reviewers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Materials_MaterialId",
                table: "Trainings",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviewers_Users_UserId",
                table: "Reviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Materials_MaterialId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ReviewerTraining");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_MaterialId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Reviewers_UserId",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reviewers");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewerTrainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewerTrainings", x => new { x.TrainingId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_ReviewerTrainings_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "ReviewerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewerTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDetail",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDetail", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_TrainingDetail_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingFiles",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingFiles", x => x.TrainingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TrainingId",
                table: "Comments",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewerTrainings_ReviewerId",
                table: "ReviewerTrainings",
                column: "ReviewerId");
        }
    }
}
