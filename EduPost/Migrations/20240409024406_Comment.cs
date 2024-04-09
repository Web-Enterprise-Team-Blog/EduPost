using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "commentDate",
                table: "Comment",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "context",
                table: "Comment",
                newName: "content");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_article_id",
                table: "Comment",
                column: "article_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_article_id",
                table: "Comment",
                column: "article_id",
                principalTable: "Article",
                principalColumn: "article_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Article_article_id",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_article_id",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Comment",
                newName: "commentDate");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Comment",
                newName: "context");
        }
    }
}
