using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class _07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "article_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "article_id");
        }
    }
}
