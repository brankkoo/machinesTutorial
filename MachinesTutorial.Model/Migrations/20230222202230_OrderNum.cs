using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinesTutorial.Model.Migrations
{
    /// <inheritdoc />
    public partial class OrderNum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNum",
                table: "Steps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 1,
                column: "OrderNum",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 2,
                column: "OrderNum",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 3,
                column: "OrderNum",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 4,
                column: "OrderNum",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Steps",
                keyColumn: "StepId",
                keyValue: 5,
                column: "OrderNum",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNum",
                table: "Steps");
        }
    }
}
