using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class SeedData05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "article_id", "AgreeToTerms", "AllowFIleDownload", "article_name", "create_date", "description", "expire_date", "article_faculty", "image", "Public", "status", "user_id" },
                values: new object[,]
                {
                    { 26, true, false, "CSArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 12 },
                    { 27, true, false, "CSArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 1, 12 },
                    { 28, true, false, "CSArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 2, 12 },
                    { 29, true, false, "CSArticle04", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 3, 12 },
                    { 30, true, false, "CSArticle05", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 3, 12 },
                    { 31, true, false, "CSArticle06", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 13 },
                    { 32, true, false, "CSArticle07", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 1, 13 },
                    { 33, true, false, "CSArticle08", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 2, 13 },
                    { 34, true, false, "CSArticle09", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 3, 13 },
                    { 35, true, false, "CSArticle10", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 3, 13 },
                    { 36, true, false, "CSArticle11", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 14 },
                    { 37, true, false, "CSArticle12", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 1, 14 },
                    { 38, true, false, "CSArticle13", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 2, 14 },
                    { 39, true, false, "CSArticle14", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 3, 14 },
                    { 40, true, false, "CSArticle15", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 3, 14 },
                    { 41, true, false, "CSArticle16", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 15 },
                    { 42, true, false, "CSArticle17", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 1, 15 },
                    { 43, true, false, "CSArticle18", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 2, 15 },
                    { 44, true, false, "CSArticle19", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 3, 15 },
                    { 45, true, false, "CSArticle20", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 3, 15 },
                    { 46, true, false, "CSArticle21", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 16 },
                    { 47, true, false, "CSArticle22", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 1, 16 },
                    { 48, true, false, "CSArticle23", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 2, 16 },
                    { 49, true, false, "CSArticle24", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 3, 16 },
                    { 50, true, false, "CSArticle25", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 3, 16 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 50);
        }
    }
}
