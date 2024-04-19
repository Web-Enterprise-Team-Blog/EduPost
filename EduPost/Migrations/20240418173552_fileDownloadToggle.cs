using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class fileDownloadToggle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowFIleDownload",
                table: "Article",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 1,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 2,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 3,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 4,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 5,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 6,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 7,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 8,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 9,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 10,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 11,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 12,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 13,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 14,
                column: "AllowFIleDownload",
                value: false);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 15,
                column: "AllowFIleDownload",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowFIleDownload",
                table: "Article");
        }
    }
}
