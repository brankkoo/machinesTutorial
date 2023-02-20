using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MachinesTutorial.Model.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StepId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Progress = table.Column<int>(type: "INTEGER", nullable: true),
                    PhotoSource = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    StepId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.StepId);
                    table.ForeignKey(
                        name: "FK_Steps_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StepId = table.Column<int>(type: "INTEGER", nullable: false),
                    Source = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StepId = table.Column<int>(type: "INTEGER", nullable: false),
                    Source = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Name", "PhotoSource", "Progress", "StepId" },
                values: new object[] { 1, "wz30000 AIR COMRESSOR", "/Images/w30k/main.jpg", 0, 0 });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "StepId", "Description", "MachineId", "Title" },
                values: new object[,]
                {
                    { 1, null, 1, "Connect the air compressor to machine air input:" },
                    { 2, null, 1, "Start power:" },
                    { 3, "For more details, please check the following ID \r\nIntelligent Temperature Controller instructions", 1, "Set parameters of temperature:" },
                    { 4, "Press down for making rods down, \r\nthen material will come out.Rods for pressing material.Press upward for making rods rising.Rods for pressing material", 1, "Driving system:" },
                    { 5, "The height between base and injector mouth is 8cm. If you want adjust height, please adjust it \r\naccording to the instructions. Unscrew and remove fastening \r\nscrews and adjusting the height", 1, " Adjusting mold" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "Source", "StepId" },
                values: new object[,]
                {
                    { 1, "Images/w30k/Step1.png", 1 },
                    { 2, "Images/w30k/Step2.png", 2 },
                    { 3, "Images/w30k/Step3.png", 3 },
                    { 4, "Images/w30k/Step4.png", 4 },
                    { 5, "Images/w30k/Step5.png", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_StepId",
                table: "Photos",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_MachineId",
                table: "Steps",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_StepId",
                table: "Videos",
                column: "StepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
