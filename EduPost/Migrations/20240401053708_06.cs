using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class _06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "File",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "article_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "File",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_File_Article_ArticleId",
                table: "File",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "article_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
