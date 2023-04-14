using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cms.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHomePage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotelDoctor",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "TotelExamined",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "TotelSurgery",
                table: "HomePages");

            migrationBuilder.AlterColumn<string>(
                name: "WorkingHours",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TotalDoctor",
                table: "HomePages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalExamined",
                table: "HomePages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalSurgery",
                table: "HomePages",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDoctor",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "TotalExamined",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "TotalSurgery",
                table: "HomePages");

            migrationBuilder.AlterColumn<string>(
                name: "WorkingHours",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotelDoctor",
                table: "HomePages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotelExamined",
                table: "HomePages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotelSurgery",
                table: "HomePages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
