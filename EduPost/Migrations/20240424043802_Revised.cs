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
                    first_login = table.Column<bool>(type: "bit", nullable: true),
                    avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                name: "AYear",
                columns: table => new
                {
                    year_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    begin_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AYear", x => x.year_id);
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
                name: "Notification",
                columns: table => new
                {
                    notice_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to_user_id = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRead = table.Column<bool>(name: "isRead?", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.notice_id);
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
                name: "Article",
                columns: table => new
                {
                    article_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    article_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    article_faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    expire_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    AgreeToTerms = table.Column<bool>(type: "bit", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    AllowFIleDownload = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.article_id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    article_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    anonymous = table.Column<bool>(type: "bit", nullable: true),
                    comment_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    edited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_Comment_Article_article_id",
                        column: x => x.article_id,
                        principalTable: "Article",
                        principalColumn: "article_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    article_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    feedback_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBack", x => x.feedback_id);
                    table.ForeignKey(
                        name: "FK_FeedBack_Article_article_id",
                        column: x => x.article_id,
                        principalTable: "Article",
                        principalColumn: "article_id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserReaction",
                columns: table => new
                {
                    UserReactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    article_id = table.Column<int>(type: "int", nullable: false),
                    reaction_type = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReaction", x => x.UserReactionId);
                    table.ForeignKey(
                        name: "FK_UserReaction_Article_article_id",
                        column: x => x.article_id,
                        principalTable: "Article",
                        principalColumn: "article_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "role_id", "ConcurrencyStamp", "roleName", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Student", "STUDENT" },
                    { 3, null, "Coordinator", "COORDINATOR" },
                    { 4, null, "Manager", "MANAGER" },
                    { 5, null, "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "avatar", "ConcurrencyStamp", "user_email", "EmailConfirmed", "faculty", "first_login", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "role", "SecurityStamp", "TwoFactorEnabled", "user_name" },
                values: new object[,]
                {
                    { 1, 0, null, "61521b0c-13fb-44a0-b67c-f753cf71bba5", "TestEmail@email.com", true, "Admin", null, true, null, "TESTEMAIL@EMAIL.COM", "TESTEMAIL@EMAIL.COM", "AQAAAAIAAYagAAAAEBdGZDqY/P61BXsLDI0xzUn5ZqaiwOMGgzYjGpoJKv8eMggcDxUGL2GZcoVXetrUpA==", null, false, "Admin", "P326W733E2RXH66PPK4ZYOQRQREJTMUD", false, "TestEmail@email.com" },
                    { 2, 0, null, "d87eaa6a-5599-41b8-8ad9-a838f4f54469", "ITHead@email.com", true, "Information Tecnology", null, true, null, "ITHEAD@EMAIL.COM", "ITHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEAQBYKWo+E7dm+Ima6pOPGomuDXZgLdRgK1tLB5TzHPj02OnEYBxtByCJATakG/mrg==", null, false, "Coordinator", "44GZPSXJBR6BQBPNQYL6CLA4YJ45BLZR", false, "ITHead@email.com" },
                    { 3, 0, null, "c45238d0-e841-48e0-a3dc-977f99dc4ccc", "CSHead@email.com", true, "Computer Science", null, true, null, "CSHEAD@EMAIL.COM", "CSHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEKr/dKYAC/NQ7UcliNfcOgErqZ+BSME9uFvc+pKZvd93r1IdlPCLeaLE/4TLjD0oxA==", null, false, "Coordinator", "75CKF5JSM6GVN3T23KGNTDZWLZIRUHJ4", false, "CSHead@email.com" },
                    { 4, 0, null, "65eb5b53-ca56-486b-a259-d3298110283c", "EHead@email.com", true, "Economics", null, true, null, "EHEAD@EMAIL.COM", "EHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEI0CPsg46g7UZPhdS4w8AblJ7Rjr6ZTAHxldpci/hdk9VDZ4ZFv8Ttm/yCqYT7+ExQ==", null, false, "Coordinator", "2QYLW55AYTFQXCNENHOBC5CV7XUWNZS2", false, "EHead@email.com" },
                    { 5, 0, null, "abc639ef-d26d-41ab-966f-f7354953bc2d", "ESHead@email.com", true, "Environmental Science", null, true, null, "ESHEAD@EMAIL.COM", "ESHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEMe25e1Gl1pCWK4HMaZxKQ8LZ0K/lrHK47jLVaEPeQM3Fsnl9QUjteNm5Lgw72mrWg==", null, false, "Coordinator", "DNKIX4TEPAINNDQVTKDCVRTWOGMOA5WX", false, "ESHead@email.com" },
                    { 6, 0, null, "72db441f-2d91-4aac-8460-8009d80847d4", "PsyHead@email.com", true, "Psychology", null, true, null, "PSYHEAD@EMAIL.COM", "PSYHEAD@EMAIL.COM", "AQAAAAIAAYagAAAAEIzrdjW8BK7V/nYdV6Q7czg1WqmweIn+OxF7nNSjE79gGkchJOee73gXZGyVkwu1Eg==", null, false, "Coordinator", "WM5VWO55FUMUZ2WOELN73KXSFP7TIHXY", false, "PsyHead@email.com" },
                    { 7, 0, null, "eb09b0fb-ec00-493a-922a-dac179910c75", "ITUser01@email.com", true, "Information Tecnology", null, true, null, "ITUSER01@EMAIL.COM", "ITUSER01@EMAIL.COM", "AQAAAAIAAYagAAAAEH+sZz3bFv5Wywum0wvsGfPWHcHzrU1eP3NFCsZgCv+i4iLsX/hbwo5UAoa5DXEY1Q==", null, false, "Student", "KL4GXYEBVQCM4CMOUHUWGVA76X5GWPLK", false, "ITUser01@email.com" },
                    { 8, 0, null, "53038d4e-7b6d-4185-8e7f-2415763a63d5", "ITUser02@email.com", true, "Information Tecnology", null, true, null, "ITUSER02@EMAIL.COM", "ITUSER02@EMAIL.COM", "AQAAAAIAAYagAAAAEC2lBMmzn9Yz4SZc01Pp0gtWDaUXyEYFQkFmprsa93UzlO5IoXSktJ6WnO2wfzBAtw==", null, false, "Student", "YO6SY4A2FLBOS7ZHD4GRYTXZTKCD4JOM", false, "ITUser02@email.com" },
                    { 9, 0, null, "5288bb02-53b6-47cf-9da5-a21eb80b3b13", "ITUser03@email.com", true, "Information Tecnology", null, true, null, "ITUSER03@EMAIL.COM", "ITUSER03@EMAIL.COM", "AQAAAAIAAYagAAAAEJo3QDCo6vtJ6l1GW3RaXbYL0+jKR+Tp8/x+Ny1VoAJhh/Mb2c+JOEA3MF0K68wkUg==", null, false, "Student", "7ASQ2UGT33TIBBIGWOHIZRSTT3ZZWSHA", false, "ITUser03@email.com" },
                    { 10, 0, null, "893122b9-115a-41c3-b526-fc7cda035a6b", "ITUser04@email.com", true, "Information Tecnology", null, true, null, "ITUSER04@EMAIL.COM", "ITUSER04@EMAIL.COM", "AQAAAAIAAYagAAAAECmJwOOIUtxINztEbzdBGoIv8vic33hW/XaXWx524PnHCzAq0+r9h8qXWflV9dAreA==", null, false, "Student", "ZDEUN3C3CICWEQN6KH4AI3UFWJCWGA5A", false, "ITUser04@email.com" },
                    { 11, 0, null, "99b4129c-6f43-4332-80e8-1abfd403d54f", "ITUser05@email.com", true, "Information Tecnology", null, true, null, "ITUSER05@EMAIL.COM", "ITUSER05@EMAIL.COM", "AQAAAAIAAYagAAAAELRnJOAVIaxsmhQAwr4S4MghTgxv8ZKuJVGGcIhRaHb55dkpwnwYC86GlM9qGthE4A==", null, false, "Student", "XCVBJEVYK3X2AO3N26IMH2LTVOXNPWEN", false, "ITUser05@email.com" },
                    { 12, 0, null, "f2a383ab-3759-4516-9107-fd7b075d1f23", "CSUser01@email.com", true, "Information Tecnology", null, true, null, "CSUSER01@EMAIL.COM", "CSUSER01@EMAIL.COM", "AQAAAAIAAYagAAAAEM+mPvVomCRp2EY60mU1dycFTYnWTmGIzkvnWy1R47/zs5zd9zIrRO2uDgX/wJoJmw==", null, false, "Student", "OK5EHYUMTYTQDEY5FHJVZMIYUYUYXMP2", false, "CSUser01@email.com" },
                    { 13, 0, null, "e9466ba9-c736-43ff-bd2a-11be3ec5e498", "CSUser02@email.com", true, "Computer Science", null, true, null, "CSUSER02@EMAIL.COM", "CSUSER02@EMAIL.COM", "AQAAAAIAAYagAAAAEDwNgWYnSqcQ0paUgAuJ8f7ahqutHUQB6byIxBGwlGm9Ql2ogy4a7qGNtjx3JnPFPQ==", null, false, "Student", "7TTWSFY5RC2BESNPZDGTKYR6444ISRWL", false, "CSUser02@email.com" },
                    { 14, 0, null, "1e1d6506-c98d-4edc-9e57-3d3ae92e3415", "CSUser03@email.com", true, "Computer Science", null, true, null, "CSUSER03@EMAIL.COM", "CSUSER03@EMAIL.COM", "AQAAAAIAAYagAAAAECZvcYqCrf/Q9OXgSCx8UPFmQNAOZsSpbLFCsLsL33S8BTCrEifeIbXXdAp+i8aCnA==", null, false, "Student", "GXRCFKOFJ6GWQXSFETM463HPVZX53IHT", false, "CSUser03@email.com" },
                    { 15, 0, null, "a25560a4-6cea-42c3-bcd7-da3d0d47837d", "CSUser04@email.com", true, "Computer Science", null, true, null, "CSUSER04@EMAIL.COM", "CSUSER04@EMAIL.COM", "AQAAAAIAAYagAAAAEMvcN7RnwgZ7/zHh0W1jihYAr1gLaaq33ZbaqKNoQ9iozCO0m8Wlg0wDg7ocz7FgEA==", null, false, "Student", "YTKQSDOA7745BFSUDY7W6SPPYD7N747N", false, "CSUser04@email.com" },
                    { 16, 0, null, "cb6974a4-23cb-4c89-9712-1556a45d3454", "CSUser05@email.com", true, "Computer Science", null, true, null, "CSUSER05@EMAIL.COM", "CSUSER05@EMAIL.COM", "AQAAAAIAAYagAAAAEOL0FO85Wq17d2NU0QMVGZSA6mR0BNvXldrynNWm6KmKrmq1yG8VX1e6DtH3QYU2Aw==", null, false, "Student", "ACX65RGUUT7PJAFMCIO5YSYSFFWBU7E5", false, "CSUser05@email.com" },
                    { 17, 0, null, "10d3c0fe-77e0-4df0-8ded-4e1aad4b3afc", "EUser01@email.com", true, "Economics", null, true, null, "EUSER01@EMAIL.COM", "EUSER01@EMAIL.COM", "AQAAAAIAAYagAAAAEAivd04QPHp/7fQavTwIrfB5T2K2M8Hb0ZAP41Ia/awExIadtcDqshfx2jfXOotDlA==", null, false, "Student", "IAQJSOD2TQY7LXMCRRSCKS3QZUXILQA6", false, "EUser01@email.com" },
                    { 18, 0, null, "10a9af30-0ef7-4fc1-ace8-b018698731cc", "EUser02@email.com", true, "Economics", null, true, null, "EUSER02@EMAIL.COM", "EUSER02@EMAIL.COM", "AQAAAAIAAYagAAAAEGMhK/rn4P74QRiPQB3l//yXK/RwD9InCoof0Wefcd5k2jYIwOrPrf0WBrKZFm/gIg==", null, false, "Student", "V56H77ZW4YVY4SGP5LVMNJ6737WB2YSA", false, "EUser02@email.com" },
                    { 19, 0, null, "70a1c443-7f66-4929-adfc-1fb81197f3f4", "EUser03@email.com", true, "Economics", null, true, null, "EUSER03@EMAIL.COM", "EUSER03@EMAIL.COM", "AQAAAAIAAYagAAAAEPDAeJh6A+JEBehf0NEBZvB3LvRcagEdaAda/Bs04xvF4W/EQ4aPJr+y+VNHNqeBGg==", null, false, "Student", "IMZ3A5VMBT76HAZST2WPP5KLTDLWV33T", false, "EUser03@email.com" },
                    { 20, 0, null, "99228dd0-22fe-4ec8-864f-4cdb13e791ca", "EUser04@email.com", true, "Economics", null, true, null, "EUSER04@EMAIL.COM", "EUSER04@EMAIL.COM", "AQAAAAIAAYagAAAAEMdt84Pr6Ug+yASNcwtYvTKB+bJZ7WkUgGTC34diODYb/FY7uNBz+RLhOFbgzFOVEQ==", null, false, "Student", "5UELYUJTAG4UOSFS2OJNUYMDY7ZYIIW5", false, "EUser04@email.com" },
                    { 21, 0, null, "9f141745-0d28-4dce-9714-233bee71ce4d", "EUser05@email.com", true, "Economics", null, true, null, "EUSER05@EMAIL.COM", "EUSER05@EMAIL.COM", "AQAAAAIAAYagAAAAEBK54wJBMS3RV7TGcr8+p/jtI3YYtPgghsMtSkTnf2UHUNRNKADm2G1GUaNJ04Wlgw==", null, false, "Student", "JQRR3LKVFNZDBTL2LJWDFDNKEDCG6LX4", false, "EUser05@email.com" },
                    { 22, 0, null, "a947aa4c-a5ef-4d2f-a319-764ae3f5eff7", "ESUser01@email.com", true, "Environmental Science", null, true, null, "ESUSER01@EMAIL.COM", "ESUSER01@EMAIL.COM", "AQAAAAIAAYagAAAAEJhgdL152HNry7J6e36yAv/98jwEGXAeab9RSjHXZsdIelGepDI4CmjwfVpQgbIVAg==", null, false, "Student", "AXAATFLRWYPAZOG6LPR6K4MBCIHYAZJB", false, "ESUser01@email.com" },
                    { 23, 0, null, "30ca9a5d-1e02-49a8-ab89-1551471fc64c", "ESUser02@email.com", true, "Environmental Science", null, true, null, "ESUSER02@EMAIL.COM", "ESUSER02@EMAIL.COM", "AQAAAAIAAYagAAAAELzFSAEFTMz0Dgl+VzntRtsNsCJhioszMJDwUAiYlYXyBaDF0xjudaa72U4zx0Q86g==", null, false, "Student", "XEZ6OMBNZXPZGBOMYHWN4JLETBMQ3GNK", false, "ESUser02@email.com" },
                    { 24, 0, null, "f3889225-34ec-4bf6-816e-fba33dfd5106", "ESUser03@email.com", true, "Environmental Science", null, true, null, "ESUSER03@EMAIL.COM", "ESUSER03@EMAIL.COM", "AQAAAAIAAYagAAAAECbwF+ooB8JLSU5tLaFfAWb28KEWNLnzwCwCvgOjbprdcXNyPeKa7uL/1sqiU6xUQw==", null, false, "Student", "YVJZW5VEG5SZRYHNQBZEE4WC7MZIMGHW", false, "ESUser03@email.com" },
                    { 25, 0, null, "16e3a4d0-88ae-4916-9656-b280e34763f4", "ESUser04@email.com", true, "Environmental Science", null, true, null, "ESUSER04@EMAIL.COM", "ESUSER04@EMAIL.COM", "AQAAAAIAAYagAAAAENONevDUHddwSZLoZjytH0nbn6ixfztlFSrrFBmZ1uesL6r30tvrtAW4CAncBBkafw==", null, false, "Student", "OP64D2UPIP6LUCMAEI24Z6FJBNVPKUV7", false, "ESUser04@email.com" },
                    { 26, 0, null, "defe4e78-a3cc-40c7-b070-dd6f92c60997", "ESUser05@email.com", true, "Environmental Science", null, true, null, "ESUSER05@EMAIL.COM", "ESUSER05@EMAIL.COM", "AQAAAAIAAYagAAAAEPYETRsECMaYW9pa2kqQRktTlH9TnhontVB6wiLsOqv5eqTosWrpVFlhAk10HSQl3Q==", null, false, "Student", "24PBFQAHGHOFTJX7UGRL35L2EHM7UESE", false, "ESUser05@email.com" },
                    { 27, 0, null, "90c7e325-5be0-415e-adcf-0bc18a4dfaad", "PsyUser01@email.com", true, "Psychology", null, true, null, "PSYUSER01@EMAIL.COM", "PSYUSER01@EMAIL.COM", "AQAAAAIAAYagAAAAEODsyP6P0oszjGKZzYMdNf1331lCyJVz/n+lu2tHF3kf+SBiaF7RprSRYlLtTqYOVw==", null, false, "Student", "IRVL5JE5K4S425UP5ES4LUOQNCKXMMC3", false, "PsyUser01@email.com" },
                    { 28, 0, null, "e3dfe8ff-bcc0-41f5-b5aa-f263ebea1d2a", "PsyUser02@email.com", true, "Psychology", null, true, null, "PSYUSER02@EMAIL.COM", "PSYUSER02@EMAIL.COM", "AQAAAAIAAYagAAAAENTHkTf31WrTlgolSHKQoyJMtc5Qb1XIqf3Btf2D4tX5gDVpl+N7XYoNcfBb1igFAw==", null, false, "Student", "NNMI25CTCT7KMJQXQ74TDEGSDNCT3J5M", false, "PsyUser02@email.com" },
                    { 29, 0, null, "290fb457-b40b-4362-bf73-67eafefc5876", "PsyUser03@email.com", true, "Psychology", null, true, null, "PSYUSER03@EMAIL.COM", "PSYUSER03@EMAIL.COM", "AQAAAAIAAYagAAAAEDxxhhO8txD83XWSKBaKTs7X1HzWWk1Ecl0aKwOG3mN59mfV6p16ZRKt0yadIvNACA==", null, false, "Student", "DFJYGHAMFOWOR72BLPUSELLKYYJD3T6J", false, "PsyUser03@email.com" },
                    { 30, 0, null, "930395d4-6e59-4cfc-aed4-44192eac0305", "PsyUser04@email.com", true, "Psychology", null, true, null, "PSYUSER04@EMAIL.COM", "PSYUSER04@EMAIL.COM", "AQAAAAIAAYagAAAAEB6Ha0jkkNag9OHx/Dq1HwAwJauvahdbp7ki7Lr+2FKsvvUE0IXY98XfQgzRvdwpuQ==", null, false, "Student", "JSSUWL7M74TZ2FOMCIE66IV4N6SPYOB4", false, "PsyUser04@email.com" },
                    { 31, 0, null, "68ebe619-deb6-4629-a8cd-c03ef0b4139e", "PsyUser05@email.com", true, "Psychology", null, true, null, "PSYUSER05@EMAIL.COM", "PSYUSER05@EMAIL.COM", "AQAAAAIAAYagAAAAEI0JMfnBTubwrLegASyI6D4tGI6pcHi9az6KhfNfVok21EGAASW6XirbG8M4w+Lm1Q==", null, false, "Student", "RW224HJ53CXKBTXANOSX64GG5H2XOYPN", false, "PsyUser05@email.com" },
                    { 32, 0, null, "2040ba93-fae1-49d7-a2f3-2fdd94874d7d", "Manager@email.com", true, "Marketing Manager", null, true, null, "MANAGER@EMAIL.COM", "MANAGER@EMAIL.COM", "AQAAAAIAAYagAAAAEDiXmLWJOrrGVy3GrXOPrQLAGeS2PlxNt5j11sB0OUrbvL5YE333FMykZjkvW2s/wg==", null, false, "Manager", "V4VYKCZNXY76FWYHKSDCEGLO2MP2FS5P", false, "Manager@email.com" }
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
                table: "Article",
                columns: new[] { "article_id", "AgreeToTerms", "AllowFIleDownload", "article_name", "create_date", "description", "expire_date", "article_faculty", "image", "Public", "status", "user_id" },
                values: new object[,]
                {
                    { 1, true, false, "ITArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 36, 895, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 0, 7 },
                    { 2, true, false, "ITArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4713), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 52, 633, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 0, 7 },
                    { 3, true, false, "ITArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3506), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 11, 59, 722, DateTimeKind.Unspecified).AddTicks(3572), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, false, 0, 7 },
                    { 4, true, false, "ITArticle04", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(1948), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 11, 487, DateTimeKind.Unspecified).AddTicks(2005), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, false, 0, 7 },
                    { 5, true, false, "ITArticle05", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 12, 24, 227, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 7, 0, 0, 0)), "Information Tecnology", null, true, 0, 7 },
                    { 6, true, false, "CSArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 13, 42, 780, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 13, 42, 780, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 8 },
                    { 7, true, false, "CSArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 13, 50, 639, DateTimeKind.Unspecified).AddTicks(4727), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 13, 50, 639, DateTimeKind.Unspecified).AddTicks(4775), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, false, 0, 8 },
                    { 8, true, false, "CSArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 14, 1, 586, DateTimeKind.Unspecified).AddTicks(277), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 14, 1, 586, DateTimeKind.Unspecified).AddTicks(327), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 8 },
                    { 9, true, false, "CSArticle04", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 14, 11, 955, DateTimeKind.Unspecified).AddTicks(2979), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 14, 11, 955, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 7, 0, 0, 0)), "Computer Science", null, true, 0, 8 },
                    { 10, true, false, "EArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 0, 935, DateTimeKind.Unspecified).AddTicks(7115), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 0, 935, DateTimeKind.Unspecified).AddTicks(7182), new TimeSpan(0, 7, 0, 0, 0)), "Economics", null, true, 0, 9 },
                    { 11, true, false, "EArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 7, 767, DateTimeKind.Unspecified).AddTicks(7437), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 7, 767, DateTimeKind.Unspecified).AddTicks(7483), new TimeSpan(0, 7, 0, 0, 0)), "Economics", null, false, 0, 9 },
                    { 12, true, false, "EArticle03", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 16, 422, DateTimeKind.Unspecified).AddTicks(1925), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 16, 422, DateTimeKind.Unspecified).AddTicks(1982), new TimeSpan(0, 7, 0, 0, 0)), "Economics", null, true, 0, 9 },
                    { 13, true, false, "ESArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 41, 591, DateTimeKind.Unspecified).AddTicks(5518), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 41, 591, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 7, 0, 0, 0)), "Environmental Science", null, true, 0, 10 },
                    { 14, true, false, "ESArticle02", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 15, 50, 428, DateTimeKind.Unspecified).AddTicks(8359), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 15, 50, 428, DateTimeKind.Unspecified).AddTicks(8402), new TimeSpan(0, 7, 0, 0, 0)), "Environmental Science", null, true, 0, 10 },
                    { 15, true, false, "PsyArticle01", new DateTimeOffset(new DateTime(2024, 4, 2, 20, 16, 26, 676, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 7, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 4, 16, 20, 16, 26, 676, DateTimeKind.Unspecified).AddTicks(431), new TimeSpan(0, 7, 0, 0, 0)), "Psychology", null, true, 0, 11 }
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
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 2, 26 },
                    { 2, 27 },
                    { 2, 28 },
                    { 2, 29 },
                    { 2, 30 },
                    { 2, 31 },
                    { 2, 32 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_user_id",
                table: "Article",
                column: "user_id");

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
                name: "IX_Comment_article_id",
                table: "Comment",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_article_id",
                table: "FeedBack",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_File_ArticleId",
                table: "File",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReaction_article_id",
                table: "UserReaction",
                column: "article_id");
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
                name: "AYear");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "UserReaction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
