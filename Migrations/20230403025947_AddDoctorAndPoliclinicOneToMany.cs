using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cms.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorAndPoliclinicOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoliclinicId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PoliclinicId",
                table: "Doctors",
                column: "PoliclinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Policlinics_PoliclinicId",
                table: "Doctors",
                column: "PoliclinicId",
                principalTable: "Policlinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Policlinics_PoliclinicId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PoliclinicId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PoliclinicId",
                table: "Doctors");
        }
    }
}
