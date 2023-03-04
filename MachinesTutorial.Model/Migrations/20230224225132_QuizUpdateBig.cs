using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinesTutorial.Model.Migrations
{
    /// <inheritdoc />
    public partial class QuizUpdateBig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Machines_MachineId",
                table: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "QuizQuestion");

            migrationBuilder.RenameTable(
                name: "QuizQuestion",
                newName: "QuizQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestion_MachineId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_MachineId");

            migrationBuilder.AddColumn<int>(
                name: "QuizGrade",
                table: "Machines",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "QuizQuestions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentChoice",
                table: "QuizQuestions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderNum",
                table: "QuizQuestions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuizChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Choice = table.Column<string>(type: "TEXT", nullable: true),
                    QuizQuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizChoices_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuizGrade",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_QuizChoices_QuizQuestionId",
                table: "QuizChoices",
                column: "QuizQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Machines_MachineId",
                table: "QuizQuestions",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Machines_MachineId",
                table: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "QuizChoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "QuizGrade",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "CurrentChoice",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "OrderNum",
                table: "QuizQuestions");

            migrationBuilder.RenameTable(
                name: "QuizQuestions",
                newName: "QuizQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_MachineId",
                table: "QuizQuestion",
                newName: "IX_QuizQuestion_MachineId");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "QuizQuestion",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestion",
                table: "QuizQuestion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Machines_MachineId",
                table: "QuizQuestion",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
