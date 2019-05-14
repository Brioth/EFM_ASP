using Microsoft.EntityFrameworkCore.Migrations;

namespace EFM_Mixed.Migrations
{
    public partial class uniqueIdex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_Name",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Assignments_Name",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name",
                table: "Employees",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_Name",
                table: "Assignments",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Name",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_Name",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_Name",
                table: "Employees",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Assignments_Name",
                table: "Assignments",
                column: "Name");
        }
    }
}
