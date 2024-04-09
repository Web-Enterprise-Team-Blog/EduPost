using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class Comment4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 1,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 2,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 3,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 4,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 5,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 6,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 7,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 8,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 9,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 10,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 11,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 12,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 13,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 14,
                column: "description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 15,
                column: "description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Article");
        }
    }
}
