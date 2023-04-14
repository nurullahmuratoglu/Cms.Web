using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cms.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Blogs_BlogId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_BlogId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_BlogId",
                table: "Doctors",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Blogs_BlogId",
                table: "Doctors",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");
        }
    }
}
