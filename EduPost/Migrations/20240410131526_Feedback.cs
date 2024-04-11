using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class Feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Article_article_id",
                table: "FeedBack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBack",
                table: "FeedBack");

            migrationBuilder.RenameTable(
                name: "FeedBack",
                newName: "FeedBack");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBack_article_id",
                table: "FeedBack",
                newName: "IX_Comment_article_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "FeedBack",
                column: "comment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_article_id",
                table: "FeedBack",
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
                table: "FeedBack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "FeedBack");

            migrationBuilder.RenameTable(
                name: "FeedBack",
                newName: "FeedBack");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_article_id",
                table: "FeedBack",
                newName: "IX_FeedBack_article_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBack",
                table: "FeedBack",
                column: "comment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Article_article_id",
                table: "FeedBack",
                column: "article_id",
                principalTable: "Article",
                principalColumn: "article_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
