using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPost.Migrations
{
    /// <inheritdoc />
    public partial class Revised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    article_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    article_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    article_faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    expire_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    AgreeToTerms = table.Column<bool>(type: "bit", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.article_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    context = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    article_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    commentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.comment_id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    faculty_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    facultyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.faculty_id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    file_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    file_content_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.file_id);
                    table.ForeignKey(
                        name: "FK_File_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "article_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "article_id", "AgreeToTerms", "article_name", "create_date", "expire_date", "article_faculty", "Public", "status", "user_id" },
                values: new object[,]
                {
                    { 1, true, "ITArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", true, 0, 7 },
                    { 2, true, "ITArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", true, 0, 7 },
                    { 3, true, "ITArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", false, 0, 7 },
                    { 4, true, "ITArticle04", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", false, 0, 7 },
                    { 5, true, "ITArticle05", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", true, 0, 7 },
                    { 6, true, "CSArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 13, 42, 780, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 13, 42, 780, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", true, 0, 8 },
                    { 7, true, "CSArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 13, 50, 639, DateTimeKind.Unspecified).AddTicks(4727), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 13, 50, 639, DateTimeKind.Unspecified).AddTicks(4775), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", false, 0, 8 },
                    { 8, true, "CSArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 14, 1, 586, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 14, 1, 586, DateTimeKind.Unspecified).AddTicks(327), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", true, 0, 8 },
                    { 9, true, "CSArticle04", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 14, 11, 955, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 14, 11, 955, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", true, 0, 8 },
                    { 10, true, "EArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 0, 935, DateTimeKind.Unspecified).AddTicks(7115), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 0, 935, DateTimeKind.Unspecified).AddTicks(7182), new TimeSpan(0, 7, 0, 0, 0)), "Economics", true, 0, 9 },
                    { 11, true, "EArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 7, 767, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 7, 767, DateTimeKind.Unspecified).AddTicks(7483), new TimeSpan(0, 7, 0, 0, 0)), "Economics", false, 0, 9 },
                    { 12, true, "EArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 16, 422, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 16, 422, DateTimeKind.Unspecified).AddTicks(1982), new TimeSpan(0, 7, 0, 0, 0)), "Economics", true, 0, 9 },
                    { 13, true, "ESArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 41, 591, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 41, 591, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), "Environmental Science", true, 0, 10 },
                    { 14, true, "ESArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 50, 428, DateTimeKind.Unspecified).AddTicks(8359), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 50, 428, DateTimeKind.Unspecified).AddTicks(8402), new TimeSpan(0, 7, 0, 0, 0)), "Environmental Science", true, 0, 10 },
                    { 15, true, "PsyArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 16, 26, 676, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 16, 20, 16, 26, 676, DateTimeKind.Unspecified).AddTicks(431), new TimeSpan(0, 7, 0, 0, 0)), "Psychology", true, 0, 11 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "role_id", "ConcurrencyStamp", "roleName", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "User", "USER" },
                    { 3, null, "Coordinator", "COORDINATOR" },
                    { 4, null, "Manager", "MANAGER" },
                    { 5, null, "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "user_email", "EmailConfirmed", "faculty", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "role", "SecurityStamp", "TwoFactorEnabled", "user_name" },
                values: new object[,]
                {
                    { 1, 0, "61521b0c-13fb-44a0-b67c-f753cf71bba5", "TestEmail@email.com", true, "Admin", true, null, "TESTEMAIL@EMAIL.COM", "TESTEMAIL@EMAIL.COM", "AQAAAAIAAYagAAAAEBdGZDqY/P61BXsLDI0xzUn5ZqaiwOMGgzYjGpoJKv8eMggcDxUGL2GZcoVXetrUpA==", null, false, "Admin", "P326W733E2RXH66PPK4ZYOQRQREJTMUD", false, "TestEmail@email.com" },
                    { 2, 0, "d87eaa6a-5599-41b8-8ad9-a838f4f54469", "ITHead@email.com", true, "Information Tecnology", true, null, "ITHEAD@EMAIL.COM", "ITHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEAQBYKWo+E7dm+Ima6pOPGomuDXZgLdRgK1tLB5TzHPj02OnEYBxtByCJATakG/mrg==", null, false, "Coordinator", "44GZPSXJBR6BQBPNQYL6CLA4YJ45BLZR", false, "ITHead@email.com" },
                    { 3, 0, "c45238d0-e841-48e0-a3dc-977f99dc4ccc", "CSHead@email.com", true, "Computer Science", true, null, "CSHEAD@EMAIL.COM", "CSHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEKr/dKYAC/NQ7UcliNfcOgErqZ+BSME9uFvc+pKZvd93r1IdlPCLeaLE/4TLjD0oxA==", null, false, "Coordinator", "75CKF5JSM6GVN3T23KGNTDZWLZIRUHJ4", false, "CSHead@email.com" },
                    { 4, 0, "65eb5b53-ca56-486b-a259-d3298110283c", "EHead@email.com", true, "Economics", true, null, "EHEAD@EMAIL.COM", "EHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEI0CPsg46g7UZPhdS4w8AblJ7Rjr6ZTAHxldpci/hdk9VDZ4ZFv8Ttm/yCqYT7+ExQ==", null, false, "Coordinator", "2QYLW55AYTFQXCNENHOBC5CV7XUWNZS2", false, "EHead@email.com" },
                    { 5, 0, "abc639ef-d26d-41ab-966f-f7354953bc2d", "ESHead@email.com", true, "Environmental Science", true, null, "ESHEAD@EMAIL.COM", "ESHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEMe25e1Gl1pCWK4HMaZxKQ8LZ0K/lrHK47jLVaEPeQM3Fsnl9QUjteNm5Lgw72mrWg==", null, false, "Coordinator", "DNKIX4TEPAINNDQVTKDCVRTWOGMOA5WX", false, "ESHead@email.com" },
                    { 6, 0, "72db441f-2d91-4aac-8460-8009d80847d4", "PsyHead@email.com", true, "Psychology", true, null, "PSYHEAD@EMAIL.COM", "PSYHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEIzrdjW8BK7V/nYdV6Q7czg1WqmweIn+OxF7nNSjE79gGkchJOee73gXZGyVkwu1Eg==", null, false, "Coordinator", "WM5VWO55FUMUZ2WOELN73KXSFP7TIHXY", false, "PsyHead@email.com" },
                    { 7, 0, "eb09b0fb-ec00-493a-922a-dac179910c75", "ITUser@email.com", true, "Information Tecnology", true, null, "ITUSER@EMAIL.COM", "ITUSER@EMAIL.COM", "AQAAAAIAAYagAAAAEH+sZz3bFv5Wywum0wvsGfPWHcHzrU1eP3NFCsZgCv+i4iLsX/hbwo5UAoa5DXEY1Q==", null, false, "User", "KL4GXYEBVQCM4CMOUHUWGVA76X5GWPLK", false, "ITUser@email.com" },
                    { 8, 0, "53038d4e-7b6d-4185-8e7f-2415763a63d5", "CSUser@email.com", true, "Computer Science", true, null, "CSUSER@EMAIL.COM", "CSUSER@EMAIL.COM", "AQAAAAIAAYagAAAAEC2lBMmzn9Yz4SZc01Pp0gtWDaUXyEYFQkFmprsa93UzlO5IoXSktJ6WnO2wfzBAtw==", null, false, "User", "YO6SY4A2FLBOS7ZHD4GRYTXZTKCD4JOM", false, "CSUser@email.com" },
                    { 9, 0, "5288bb02-53b6-47cf-9da5-a21eb80b3b13", "EUser@email.com", true, "Economics", true, null, "EUSER@EMAIL.COM", "EUSER@EMAIL.COM", "AQAAAAIAAYagAAAAEJo3QDCo6vtJ6l1GW3RaXbYL0+jKR+Tp8/x+Ny1VoAJhh/Mb2c+JOEA3MF0K68wkUg==", null, false, "User", "7ASQ2UGT33TIBBIGWOHIZRSTT3ZZWSHA", false, "EUser@email.com" },
                    { 10, 0, "893122b9-115a-41c3-b526-fc7cda035a6b", "ESUser@email.com", true, "Environmental Science", true, null, "ESUSER@EMAIL.COM", "ESUSER@EMAIL.COM", "AQAAAAIAAYagAAAAECmJwOOIUtxINztEbzdBGoIv8vic33hW/XaXWx524PnHCzAq0+r9h8qXWflV9dAreA==", null, false, "User", "ZDEUN3C3CICWEQN6KH4AI3UFWJCWGA5A", false, "ESUser@email.com" },
                    { 11, 0, "99b4129c-6f43-4332-80e8-1abfd403d54f", "PsyUser@email.com", true, "Psychology", true, null, "PSYUSER@EMAIL.COM", "PSYUSER@EMAIL.COM", "AQAAAAIAAYagAAAAELRnJOAVIaxsmhQAwr4S4MghTgxv8ZKuJVGGcIhRaHb55dkpwnwYC86GlM9qGthE4A==", null, false, "User", "XCVBJEVYK3X2AO3N26IMH2LTVOXNPWEN", false, "PsyUser@email.com" },
                    { 12, 0, "f2a383ab-3759-4516-9107-fd7b075d1f23", "Manager@email.com", true, "Information Tecnology", true, null, "MANAGER@EMAIL.COM", "MANAGER@EMAIL.COM", "AQAAAAIAAYagAAAAEM+mPvVomCRp2EY60mU1dycFTYnWTmGIzkvnWy1R47/zs5zd9zIrRO2uDgX/wJoJmw==", null, false, "User", "OK5EHYUMTYTQDEY5FHJVZMIYUYUYXMP2", false, "Manager@email.com" }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "faculty_id", "facultyName" },
                values: new object[,]
                {
                    { 1, "Information Tecnology" },
                    { 2, "Computer Science" },
                    { 3, "Economics" },
                    { 4, "Environmental Science" },
                    { 5, "Psychology" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 4, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_File_ArticleId",
                table: "File",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
