using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MachinesTutorial.Model.Migrations
{
    /// <inheritdoc />
    public partial class QuizUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderNum",
                table: "Steps",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "QuizQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: true),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 1,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "Fix the mould to the under vice, tight it well and proceed with the operation of the\r\nmachine", 1, "Step 1" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 2,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "Air connection: Verify the air compressor is on and the air pressure hose is\r\nconnected to the machine", 2, "Step 2" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 3,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "Start", 3, "Step 3" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 4,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "Set temperature parameter", 4, "Step 4" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 5,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "Pull the lever down in order for the rod to go down and press the heated plastic.", 5, "Step 5" });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "StepId", "Description", "MachineId", "OrderNum", "Title" },
                values: new object[,]
                {
                    { 6, "After the rod has pressed the molten material you must push the lever up for the rod\r\nto go upwards", 1, 6, "Step 6" },
                    { 7, "Open the mould and get the final product.\r\nIf the height of the mould is not correct, on the back of the machine you will see 2 screws\r\nwhich you can use to move the machine up and down.", 1, 7, "Step 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_MachineId",
                table: "QuizQuestion",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizQuestion");

            migrationBuilder.DeleteData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 7);

            migrationBuilder.AlterColumn<int>(
                name: "OrderNum",
                table: "Steps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 1,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { null, 0, "Connect the air compressor to machine air input:" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 2,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { null, 0, "Start power:" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 3,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "For more details, please check the following ID \r\nIntelligent Temperature Controller instructions", 0, "Set parameters of temperature:" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 4,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "Press down for making rods down, \r\nthen material will come out.Rods for pressing material.Press upward for making rods rising.Rods for pressing material", 0, "Driving system:" });

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 5,
                columns: new[] { "Description", "OrderNum", "Title" },
                values: new object[] { "The height between base and injector mouth is 8cm. If you want adjust height, please adjust it \r\naccording to the instructions. Unscrew and remove fastening \r\nscrews and adjusting the height", 0, " Adjusting mold" });
        }
    }
}
