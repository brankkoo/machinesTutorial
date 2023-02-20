using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinesTutorial.Model.Migrations
{
    /// <inheritdoc />
    public partial class description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Steps_StepId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Steps_StepId",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Videos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Photos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Machines",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Steps_StepId",
                table: "Photos",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Steps_StepId",
                table: "Videos",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "StepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Steps_StepId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Steps_StepId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Videos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Steps_StepId",
                table: "Photos",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Steps_StepId",
                table: "Videos",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
