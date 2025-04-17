using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dept_ID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dept_ID",
                table: "Employees",
                column: "Dept_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Dept_ID",
                table: "Employees",
                column: "Dept_ID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Dept_ID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Dept_ID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Dept_ID",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
