using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class SeedData01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 1,
                column: "expire_date",
                value: new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 2,
                columns: new[] { "expire_date", "status" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 3,
                columns: new[] { "expire_date", "status" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), 2 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 4,
                column: "status",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 5,
                column: "status",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 6,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty" },
                values: new object[] { "ITArticle06", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology" });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 7,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status" },
                values: new object[] { "ITArticle07", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", true, 1 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 8,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status" },
                values: new object[] { "ITArticle08", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", false, 2 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 9,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status" },
                values: new object[] { "ITArticle09", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", false, 3 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 10,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "status", "user_id" },
                values: new object[] { "ITArticle10", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", 3, 8 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 11,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public" },
                values: new object[] { "ITArticle11", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", true });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 12,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "status" },
                values: new object[] { "ITArticle12", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", 1 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 13,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status", "user_id" },
                values: new object[] { "ITArticle13", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", false, 2, 9 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 14,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status", "user_id" },
                values: new object[] { "ITArticle14", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", false, 3, 9 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 15,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "status", "user_id" },
                values: new object[] { "ITArticle15", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", 3, 10 });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "article_id", "AgreeToTerms", "AllowFIleDownload", "article_name", "create_date", "description", "expire_date", "article_faculty", "image", "Public", "status", "user_id" },
                values: new object[,]
                {
                    { 16, true, false, "ITArticle16", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 0, 10 },
                    { 17, true, false, "ITArticle17", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 1, 10 },
                    { 18, true, false, "ITArticle18", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, false, 2, 10 },
                    { 19, true, false, "ITArticle19", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, false, 3, 10 },
                    { 20, true, false, "ITArticle20", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 3, 10 },
                    { 21, true, false, "ITArticle21", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 0, 11 },
                    { 22, true, false, "ITArticle22", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 1, 11 },
                    { 23, true, false, "ITArticle23", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 30, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, false, 2, 11 },
                    { 24, true, false, "ITArticle24", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, false, 3, 11 },
                    { 25, true, false, "ITArticle25", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 3, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 1,
                column: "expire_date",
                value: new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 2,
                columns: new[] { "expire_date", "status" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 3,
                columns: new[] { "expire_date", "status" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 4,
                column: "status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 5,
                column: "status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 6,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty" },
                values: new object[] { "CSArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 13, 42, 780, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 13, 42, 780, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science" });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 7,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status" },
                values: new object[] { "CSArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 13, 50, 639, DateTimeKind.Unspecified).AddTicks(4727), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 13, 50, 639, DateTimeKind.Unspecified).AddTicks(4775), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", false, 0 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 8,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status" },
                values: new object[] { "CSArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 14, 1, 586, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 14, 1, 586, DateTimeKind.Unspecified).AddTicks(327), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", true, 0 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 9,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status" },
                values: new object[] { "CSArticle04", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 14, 11, 955, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 14, 11, 955, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", true, 0 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 10,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "status", "user_id" },
                values: new object[] { "EArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 0, 935, DateTimeKind.Unspecified).AddTicks(7115), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 0, 935, DateTimeKind.Unspecified).AddTicks(7182), new TimeSpan(0, 7, 0, 0, 0)), "Economics", 0, 9 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 11,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public" },
                values: new object[] { "EArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 7, 767, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 7, 767, DateTimeKind.Unspecified).AddTicks(7483), new TimeSpan(0, 7, 0, 0, 0)), "Economics", false });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 12,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "status" },
                values: new object[] { "EArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 16, 422, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 16, 422, DateTimeKind.Unspecified).AddTicks(1982), new TimeSpan(0, 7, 0, 0, 0)), "Economics", 0 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 13,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status", "user_id" },
                values: new object[] { "ESArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 41, 591, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 41, 591, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), "Environmental Science", true, 0, 10 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 14,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "Public", "status", "user_id" },
                values: new object[] { "ESArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 50, 428, DateTimeKind.Unspecified).AddTicks(8359), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 50, 428, DateTimeKind.Unspecified).AddTicks(8402), new TimeSpan(0, 7, 0, 0, 0)), "Environmental Science", true, 0, 10 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "article_id",
                keyValue: 15,
                columns: new[] { "article_name", "create_date", "expire_date", "article_faculty", "status", "user_id" },
                values: new object[] { "PsyArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 16, 26, 676, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 16, 26, 676, DateTimeKind.Unspecified).AddTicks(431), new TimeSpan(0, 7, 0, 0, 0)), "Psychology", 0, 11 });
        }
    }
}
