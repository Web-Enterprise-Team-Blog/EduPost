using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class homeView1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Article_user_id",
                table: "Article",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_AspNetUsers_user_id",
                table: "Article",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_AspNetUsers_user_id",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_user_id",
                table: "Article");
        }
    }
}
