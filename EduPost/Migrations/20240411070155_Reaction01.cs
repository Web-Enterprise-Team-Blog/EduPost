using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class Reaction01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReaction_Article_ArticleId",
                table: "UserReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReaction_AspNetUsers_UserId",
                table: "UserReaction");

            migrationBuilder.DropIndex(
                name: "IX_UserReaction_ArticleId",
                table: "UserReaction");

            migrationBuilder.DropIndex(
                name: "IX_UserReaction_UserId",
                table: "UserReaction");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserReaction",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ReactionType",
                table: "UserReaction",
                newName: "reaction_type");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "UserReaction",
                newName: "article_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserReaction",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "reaction_type",
                table: "UserReaction",
                newName: "ReactionType");

            migrationBuilder.RenameColumn(
                name: "article_id",
                table: "UserReaction",
                newName: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReaction_ArticleId",
                table: "UserReaction",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReaction_UserId",
                table: "UserReaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReaction_Article_ArticleId",
                table: "UserReaction",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "article_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReaction_AspNetUsers_UserId",
                table: "UserReaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
