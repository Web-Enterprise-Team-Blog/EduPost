using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class addImageToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Article",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 1,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 2,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 3,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 4,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 5,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 6,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 7,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 8,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 9,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 10,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 11,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 12,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 13,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 14,
                column: "image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 15,
                column: "image",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Article");
        }
    }
}
