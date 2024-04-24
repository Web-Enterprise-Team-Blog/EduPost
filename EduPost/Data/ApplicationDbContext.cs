using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EduPost.Models;
using System.Data;
using System.Reflection.Emit;
using File = EduPost.Models.File;

namespace EduPost.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EduPost.Models.User>? User { get; set; }
        public DbSet<EduPost.Models.Article>? Article { get; set; }
        public DbSet<EduPost.Models.Status>? Status { get; set; }
        public DbSet<EduPost.Models.Comment>? Comment { get; set; }
        public DbSet<EduPost.Models.FeedBack>? FeedBack { get; set; }
        public DbSet<EduPost.Models.Notification>? Notification { get; set; }
		public DbSet<EduPost.Models.UserReaction>? UserReaction { get; set; }
		public DbSet<EduPost.Models.AYear>? AYear { get; set; }
		public DbSet<EduPost.Models.File>? File { get; set; }
        public DbSet<EduPost.Models.Faculty>? Faculty { get; set; } = default!;
        public DbSet<EduPost.Models.Role>? Role { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>()
            .HasMany(a => a.Files)
            .WithOne(f => f.Article)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Article>()
            .HasMany(a => a.Comments) 
            .WithOne()
            .HasForeignKey(c => c.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Article>()
            .HasMany(a => a.FeedBacks)
            .WithOne()
            .HasForeignKey(c => c.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);

			builder.Entity<Article>()
			.HasMany(a => a.UserReactions)
			.WithOne()
			.HasForeignKey(c => c.ArticleId)
			.OnDelete(DeleteBehavior.Cascade);

			SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            var adminusers = new[]
            {
                new User 
                { 
                    Id = 1, 
                    UserName = "TestEmail@email.com",
                    Email = "TestEmail@email.com",
                    Faculty = "Admin",
                    Role = "Admin",
                    NormalizedUserName = "TESTEMAIL@EMAIL.COM",
                    NormalizedEmail = "TESTEMAIL@EMAIL.COM",
                    EmailConfirmed = true,
                    //Pasword:Admin@01
                    PasswordHash = "AQAAAAIAAYagAAAAEBdGZDqY/P61BXsLDI0xzUn5ZqaiwOMGgzYjGpoJKv8eMggcDxUGL2GZcoVXetrUpA==",
                    SecurityStamp = "P326W733E2RXH66PPK4ZYOQRQREJTMUD",
                    ConcurrencyStamp = "61521b0c-13fb-44a0-b67c-f753cf71bba5",
                    LockoutEnabled = true,
                    FirstLogin = false
                },
                new User
                {
                    Id = 2,
                    UserName = "ITHead@email.com",
                    Email = "ITHead@email.com",
                    Faculty = "Information Tecnology",
                    Role = "Coordinator",
                    NormalizedUserName = "ITHEAD@EMAIL.COM",
                    NormalizedEmail = "ITHEAD@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEAQBYKWo+E7dm+Ima6pOPGomuDXZgLdRgK1tLB5TzHPj02OnEYBxtByCJATakG/mrg==",
                    SecurityStamp = "44GZPSXJBR6BQBPNQYL6CLA4YJ45BLZR",
                    ConcurrencyStamp = "d87eaa6a-5599-41b8-8ad9-a838f4f54469",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 3,
                    UserName = "CSHead@email.com",
                    Email = "CSHead@email.com",
                    Faculty = "Computer Science",
                    Role = "Coordinator",
                    NormalizedUserName = "CSHEAD@EMAIL.COM",
                    NormalizedEmail = "CSHEAD@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEKr/dKYAC/NQ7UcliNfcOgErqZ+BSME9uFvc+pKZvd93r1IdlPCLeaLE/4TLjD0oxA==",
                    SecurityStamp = "75CKF5JSM6GVN3T23KGNTDZWLZIRUHJ4",
                    ConcurrencyStamp = "c45238d0-e841-48e0-a3dc-977f99dc4ccc",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 4,
                    UserName = "EHead@email.com",
                    Email = "EHead@email.com",
                    Faculty = "Economics",
                    Role = "Coordinator",
                    NormalizedUserName = "EHEAD@EMAIL.COM",
                    NormalizedEmail = "EHEAD@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEI0CPsg46g7UZPhdS4w8AblJ7Rjr6ZTAHxldpci/hdk9VDZ4ZFv8Ttm/yCqYT7+ExQ==",
                    SecurityStamp = "2QYLW55AYTFQXCNENHOBC5CV7XUWNZS2",
                    ConcurrencyStamp = "65eb5b53-ca56-486b-a259-d3298110283c",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 5,
                    UserName = "ESHead@email.com",
                    Email = "ESHead@email.com",
                    Faculty = "Environmental Science",
                    Role = "Coordinator",
                    NormalizedUserName = "ESHEAD@EMAIL.COM",
                    NormalizedEmail = "ESHEAD@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEMe25e1Gl1pCWK4HMaZxKQ8LZ0K/lrHK47jLVaEPeQM3Fsnl9QUjteNm5Lgw72mrWg==",
                    SecurityStamp = "DNKIX4TEPAINNDQVTKDCVRTWOGMOA5WX",
                    ConcurrencyStamp = "abc639ef-d26d-41ab-966f-f7354953bc2d",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 6,
                    UserName = "PsyHead@email.com",
                    Email = "PsyHead@email.com",
                    Faculty = "Psychology",
                    Role = "Coordinator",
                    NormalizedUserName = "PSYHEAD@EMAIL.COM",
                    NormalizedEmail = "PSYHEAD@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEIzrdjW8BK7V/nYdV6Q7czg1WqmweIn+OxF7nNSjE79gGkchJOee73gXZGyVkwu1Eg==",
                    SecurityStamp = "WM5VWO55FUMUZ2WOELN73KXSFP7TIHXY",
                    ConcurrencyStamp = "72db441f-2d91-4aac-8460-8009d80847d4",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 7,
                    UserName = "ITUser01@email.com",
                    Email = "ITUser01@email.com",
                    Faculty = "Information Tecnology",
                    Role = "Student",
                    NormalizedUserName = "ITUSER01@EMAIL.COM",
                    NormalizedEmail = "ITUSER01@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEH+sZz3bFv5Wywum0wvsGfPWHcHzrU1eP3NFCsZgCv+i4iLsX/hbwo5UAoa5DXEY1Q==",
                    SecurityStamp = "KL4GXYEBVQCM4CMOUHUWGVA76X5GWPLK",
                    ConcurrencyStamp = "eb09b0fb-ec00-493a-922a-dac179910c75",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 8,
                    UserName = "ITUser02@email.com",
                    Email = "ITUser02@email.com",
					Faculty = "Information Tecnology",
					Role = "Student",
                    NormalizedUserName = "ITUSER02@EMAIL.COM",
                    NormalizedEmail = "ITUSER02@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEC2lBMmzn9Yz4SZc01Pp0gtWDaUXyEYFQkFmprsa93UzlO5IoXSktJ6WnO2wfzBAtw==",
                    SecurityStamp = "YO6SY4A2FLBOS7ZHD4GRYTXZTKCD4JOM",
                    ConcurrencyStamp = "53038d4e-7b6d-4185-8e7f-2415763a63d5",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 9,
                    UserName = "ITUser03@email.com",
                    Email = "ITUser03@email.com",
					Faculty = "Information Tecnology",
					Role = "Student",
                    NormalizedUserName = "ITUSER03@EMAIL.COM",
                    NormalizedEmail = "ITUSER03@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEJo3QDCo6vtJ6l1GW3RaXbYL0+jKR+Tp8/x+Ny1VoAJhh/Mb2c+JOEA3MF0K68wkUg==",
                    SecurityStamp = "7ASQ2UGT33TIBBIGWOHIZRSTT3ZZWSHA",
                    ConcurrencyStamp = "5288bb02-53b6-47cf-9da5-a21eb80b3b13",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 10,
                    UserName = "ITUser04@email.com",
                    Email = "ITUser04@email.com",
					Faculty = "Information Tecnology",
					Role = "Student",
                    NormalizedUserName = "ITUSER04@EMAIL.COM",
                    NormalizedEmail = "ITUSER04@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAECmJwOOIUtxINztEbzdBGoIv8vic33hW/XaXWx524PnHCzAq0+r9h8qXWflV9dAreA==",
                    SecurityStamp = "ZDEUN3C3CICWEQN6KH4AI3UFWJCWGA5A",
                    ConcurrencyStamp = "893122b9-115a-41c3-b526-fc7cda035a6b",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 11,
                    UserName = "ITUser05@email.com",
                    Email = "ITUser05@email.com",
					Faculty = "Information Tecnology",
					Role = "Student",
                    NormalizedUserName = "ITUSER05@EMAIL.COM",
                    NormalizedEmail = "ITUSER05@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAELRnJOAVIaxsmhQAwr4S4MghTgxv8ZKuJVGGcIhRaHb55dkpwnwYC86GlM9qGthE4A==",
                    SecurityStamp = "XCVBJEVYK3X2AO3N26IMH2LTVOXNPWEN",
                    ConcurrencyStamp = "99b4129c-6f43-4332-80e8-1abfd403d54f",
                    LockoutEnabled = true,
					FirstLogin = false
				},
                new User
                {
                    Id = 12,
                    UserName = "CSUser01@email.com",
                    Email = "CSUser01@email.com",
                    Faculty = "Information Tecnology",
                    Role = "Student",
                    NormalizedUserName = "CSUSER01@EMAIL.COM",
                    NormalizedEmail = "CSUSER01@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEM+mPvVomCRp2EY60mU1dycFTYnWTmGIzkvnWy1R47/zs5zd9zIrRO2uDgX/wJoJmw==",
                    SecurityStamp = "OK5EHYUMTYTQDEY5FHJVZMIYUYUYXMP2",
                    ConcurrencyStamp = "f2a383ab-3759-4516-9107-fd7b075d1f23",
                    LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 13,
					UserName = "CSUser02@email.com",
					Email = "CSUser02@email.com",
					Faculty = "Computer Science",
					Role = "Student",
					NormalizedUserName = "CSUSER02@EMAIL.COM",
					NormalizedEmail = "CSUSER02@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEDwNgWYnSqcQ0paUgAuJ8f7ahqutHUQB6byIxBGwlGm9Ql2ogy4a7qGNtjx3JnPFPQ==",
					SecurityStamp = "7TTWSFY5RC2BESNPZDGTKYR6444ISRWL",
					ConcurrencyStamp = "e9466ba9-c736-43ff-bd2a-11be3ec5e498",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 14,
					UserName = "CSUser03@email.com",
					Email = "CSUser03@email.com",
					Faculty = "Computer Science",
					Role = "Student",
					NormalizedUserName = "CSUSER03@EMAIL.COM",
					NormalizedEmail = "CSUSER03@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAECZvcYqCrf/Q9OXgSCx8UPFmQNAOZsSpbLFCsLsL33S8BTCrEifeIbXXdAp+i8aCnA==",
					SecurityStamp = "GXRCFKOFJ6GWQXSFETM463HPVZX53IHT",
					ConcurrencyStamp = "1e1d6506-c98d-4edc-9e57-3d3ae92e3415",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 15,
					UserName = "CSUser04@email.com",
					Email = "CSUser04@email.com",
					Faculty = "Computer Science",
					Role = "Student",
					NormalizedUserName = "CSUSER04@EMAIL.COM",
					NormalizedEmail = "CSUSER04@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEMvcN7RnwgZ7/zHh0W1jihYAr1gLaaq33ZbaqKNoQ9iozCO0m8Wlg0wDg7ocz7FgEA==",
					SecurityStamp = "YTKQSDOA7745BFSUDY7W6SPPYD7N747N",
					ConcurrencyStamp = "a25560a4-6cea-42c3-bcd7-da3d0d47837d",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 16,
					UserName = "CSUser05@email.com",
					Email = "CSUser05@email.com",
					Faculty = "Computer Science",
					Role = "Student",
					NormalizedUserName = "CSUSER05@EMAIL.COM",
					NormalizedEmail = "CSUSER05@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEOL0FO85Wq17d2NU0QMVGZSA6mR0BNvXldrynNWm6KmKrmq1yG8VX1e6DtH3QYU2Aw==",
					SecurityStamp = "ACX65RGUUT7PJAFMCIO5YSYSFFWBU7E5",
					ConcurrencyStamp = "cb6974a4-23cb-4c89-9712-1556a45d3454",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 17,
					UserName = "EUser01@email.com",
					Email = "EUser01@email.com",
					Faculty = "Economics",
					Role = "Student",
					NormalizedUserName = "EUSER01@EMAIL.COM",
					NormalizedEmail = "EUSER01@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEAivd04QPHp/7fQavTwIrfB5T2K2M8Hb0ZAP41Ia/awExIadtcDqshfx2jfXOotDlA==",
					SecurityStamp = "IAQJSOD2TQY7LXMCRRSCKS3QZUXILQA6",
					ConcurrencyStamp = "10d3c0fe-77e0-4df0-8ded-4e1aad4b3afc",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 18,
					UserName = "EUser02@email.com",
					Email = "EUser02@email.com",
					Faculty = "Economics",
					Role = "Student",
					NormalizedUserName = "EUSER02@EMAIL.COM",
					NormalizedEmail = "EUSER02@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEGMhK/rn4P74QRiPQB3l//yXK/RwD9InCoof0Wefcd5k2jYIwOrPrf0WBrKZFm/gIg==",
					SecurityStamp = "V56H77ZW4YVY4SGP5LVMNJ6737WB2YSA",
					ConcurrencyStamp = "10a9af30-0ef7-4fc1-ace8-b018698731cc",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 19,
					UserName = "EUser03@email.com",
					Email = "EUser03@email.com",
					Faculty = "Economics",
					Role = "Student",
					NormalizedUserName = "EUSER03@EMAIL.COM",
					NormalizedEmail = "EUSER03@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEPDAeJh6A+JEBehf0NEBZvB3LvRcagEdaAda/Bs04xvF4W/EQ4aPJr+y+VNHNqeBGg==",
					SecurityStamp = "IMZ3A5VMBT76HAZST2WPP5KLTDLWV33T",
					ConcurrencyStamp = "70a1c443-7f66-4929-adfc-1fb81197f3f4",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 20,
					UserName = "EUser04@email.com",
					Email = "EUser04@email.com",
					Faculty = "Economics",
					Role = "Student",
					NormalizedUserName = "EUSER04@EMAIL.COM",
					NormalizedEmail = "EUSER04@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEMdt84Pr6Ug+yASNcwtYvTKB+bJZ7WkUgGTC34diODYb/FY7uNBz+RLhOFbgzFOVEQ==",
					SecurityStamp = "5UELYUJTAG4UOSFS2OJNUYMDY7ZYIIW5",
					ConcurrencyStamp = "99228dd0-22fe-4ec8-864f-4cdb13e791ca",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 21,
					UserName = "EUser05@email.com",
					Email = "EUser05@email.com",
					Faculty = "Economics",
					Role = "Student",
					NormalizedUserName = "EUSER05@EMAIL.COM",
					NormalizedEmail = "EUSER05@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEBK54wJBMS3RV7TGcr8+p/jtI3YYtPgghsMtSkTnf2UHUNRNKADm2G1GUaNJ04Wlgw==",
					SecurityStamp = "JQRR3LKVFNZDBTL2LJWDFDNKEDCG6LX4",
					ConcurrencyStamp = "9f141745-0d28-4dce-9714-233bee71ce4d",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 22,
					UserName = "ESUser01@email.com",
					Email = "ESUser01@email.com",
					Faculty = "Environmental Science",
					Role = "Student",
					NormalizedUserName = "ESUSER01@EMAIL.COM",
					NormalizedEmail = "ESUSER01@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEJhgdL152HNry7J6e36yAv/98jwEGXAeab9RSjHXZsdIelGepDI4CmjwfVpQgbIVAg==",
					SecurityStamp = "AXAATFLRWYPAZOG6LPR6K4MBCIHYAZJB",
					ConcurrencyStamp = "a947aa4c-a5ef-4d2f-a319-764ae3f5eff7",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 23,
					UserName = "ESUser02@email.com",
					Email = "ESUser02@email.com",
					Faculty = "Environmental Science",
					Role = "Student",
					NormalizedUserName = "ESUSER02@EMAIL.COM",
					NormalizedEmail = "ESUSER02@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAELzFSAEFTMz0Dgl+VzntRtsNsCJhioszMJDwUAiYlYXyBaDF0xjudaa72U4zx0Q86g==",
					SecurityStamp = "XEZ6OMBNZXPZGBOMYHWN4JLETBMQ3GNK",
					ConcurrencyStamp = "30ca9a5d-1e02-49a8-ab89-1551471fc64c",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 24,
					UserName = "ESUser03@email.com",
					Email = "ESUser03@email.com",
					Faculty = "Environmental Science",
					Role = "Student",
					NormalizedUserName = "ESUSER03@EMAIL.COM",
					NormalizedEmail = "ESUSER03@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAECbwF+ooB8JLSU5tLaFfAWb28KEWNLnzwCwCvgOjbprdcXNyPeKa7uL/1sqiU6xUQw==",
					SecurityStamp = "YVJZW5VEG5SZRYHNQBZEE4WC7MZIMGHW",
					ConcurrencyStamp = "f3889225-34ec-4bf6-816e-fba33dfd5106",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 25,
					UserName = "ESUser04@email.com",
					Email = "ESUser04@email.com",
					Faculty = "Environmental Science",
					Role = "Student",
					NormalizedUserName = "ESUSER04@EMAIL.COM",
					NormalizedEmail = "ESUSER04@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAENONevDUHddwSZLoZjytH0nbn6ixfztlFSrrFBmZ1uesL6r30tvrtAW4CAncBBkafw==",
					SecurityStamp = "OP64D2UPIP6LUCMAEI24Z6FJBNVPKUV7",
					ConcurrencyStamp = "16e3a4d0-88ae-4916-9656-b280e34763f4",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 26,
					UserName = "ESUser05@email.com",
					Email = "ESUser05@email.com",
					Faculty = "Environmental Science",
					Role = "Student",
					NormalizedUserName = "ESUSER05@EMAIL.COM",
					NormalizedEmail = "ESUSER05@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEPYETRsECMaYW9pa2kqQRktTlH9TnhontVB6wiLsOqv5eqTosWrpVFlhAk10HSQl3Q==",
					SecurityStamp = "24PBFQAHGHOFTJX7UGRL35L2EHM7UESE",
					ConcurrencyStamp = "defe4e78-a3cc-40c7-b070-dd6f92c60997",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 27,
					UserName = "PsyUser01@email.com",
					Email = "PsyUser01@email.com",
					Faculty = "Psychology",
					Role = "Student",
					NormalizedUserName = "PSYUSER01@EMAIL.COM",
					NormalizedEmail = "PSYUSER01@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEODsyP6P0oszjGKZzYMdNf1331lCyJVz/n+lu2tHF3kf+SBiaF7RprSRYlLtTqYOVw==",
					SecurityStamp = "IRVL5JE5K4S425UP5ES4LUOQNCKXMMC3",
					ConcurrencyStamp = "90c7e325-5be0-415e-adcf-0bc18a4dfaad",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 28,
					UserName = "PsyUser02@email.com",
					Email = "PsyUser02@email.com",
					Faculty = "Psychology",
					Role = "Student",
					NormalizedUserName = "PSYUSER02@EMAIL.COM",
					NormalizedEmail = "PSYUSER02@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAENTHkTf31WrTlgolSHKQoyJMtc5Qb1XIqf3Btf2D4tX5gDVpl+N7XYoNcfBb1igFAw==",
					SecurityStamp = "NNMI25CTCT7KMJQXQ74TDEGSDNCT3J5M",
					ConcurrencyStamp = "e3dfe8ff-bcc0-41f5-b5aa-f263ebea1d2a",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 29,
					UserName = "PsyUser03@email.com",
					Email = "PsyUser03@email.com",
					Faculty = "Psychology",
					Role = "Student",
					NormalizedUserName = "PSYUSER03@EMAIL.COM",
					NormalizedEmail = "PSYUSER03@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEDxxhhO8txD83XWSKBaKTs7X1HzWWk1Ecl0aKwOG3mN59mfV6p16ZRKt0yadIvNACA==",
					SecurityStamp = "DFJYGHAMFOWOR72BLPUSELLKYYJD3T6J",
					ConcurrencyStamp = "290fb457-b40b-4362-bf73-67eafefc5876",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 30,
					UserName = "PsyUser04@email.com",
					Email = "PsyUser04@email.com",
					Faculty = "Psychology",
					Role = "Student",
					NormalizedUserName = "PSYUSER04@EMAIL.COM",
					NormalizedEmail = "PSYUSER04@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEB6Ha0jkkNag9OHx/Dq1HwAwJauvahdbp7ki7Lr+2FKsvvUE0IXY98XfQgzRvdwpuQ==",
					SecurityStamp = "JSSUWL7M74TZ2FOMCIE66IV4N6SPYOB4",
					ConcurrencyStamp = "930395d4-6e59-4cfc-aed4-44192eac0305",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 31,
					UserName = "PsyUser05@email.com",
					Email = "PsyUser05@email.com",
					Faculty = "Psychology",
					Role = "Student",
					NormalizedUserName = "PSYUSER05@EMAIL.COM",
					NormalizedEmail = "PSYUSER05@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEI0JMfnBTubwrLegASyI6D4tGI6pcHi9az6KhfNfVok21EGAASW6XirbG8M4w+Lm1Q==",
					SecurityStamp = "RW224HJ53CXKBTXANOSX64GG5H2XOYPN",
					ConcurrencyStamp = "68ebe619-deb6-4629-a8cd-c03ef0b4139e",
					LockoutEnabled = true,
					FirstLogin = false
				},
				new User
				{
					Id = 32,
					UserName = "Manager@email.com",
					Email = "Manager@email.com",
					Faculty = "Marketing Manager",
					Role = "Manager",
					NormalizedUserName = "MANAGER@EMAIL.COM",
					NormalizedEmail = "MANAGER@EMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = "AQAAAAIAAYagAAAAEDiXmLWJOrrGVy3GrXOPrQLAGeS2PlxNt5j11sB0OUrbvL5YE333FMykZjkvW2s/wg==",
					SecurityStamp = "V4VYKCZNXY76FWYHKSDCEGLO2MP2FS5P",
					ConcurrencyStamp = "2040ba93-fae1-49d7-a2f3-2fdd94874d7d",
					LockoutEnabled = true,
					FirstLogin = false
				}
			};
            builder.Entity<User>().HasData(adminusers);

            var userRolePairs = new[]
            {
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 3 },
                new IdentityUserRole<int> { UserId = 3, RoleId = 3 },
                new IdentityUserRole<int> { UserId = 4, RoleId = 3 },
                new IdentityUserRole<int> { UserId = 5, RoleId = 3 },
                new IdentityUserRole<int> { UserId = 6, RoleId = 3 },
                new IdentityUserRole<int> { UserId = 7, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 8, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 9, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 10, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 11, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 13, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 14, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 15, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 16, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 17, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 18, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 19, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 20, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 21, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 22, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 23, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 24, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 25, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 26, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 27, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 28, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 29, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 30, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 31, RoleId = 2 },
				new IdentityUserRole<int> { UserId = 32, RoleId = 4 }
			};
            builder.Entity<IdentityUserRole<int>>().HasData(userRolePairs);

            var roles = new[]
            { 
              new Role { Id = 1,Name = "Admin", NormalizedName = "ADMIN"},
              new Role { Id = 2,Name = "Student", NormalizedName = "STUDENT"},
              new Role { Id = 3,Name = "Coordinator", NormalizedName = "COORDINATOR"},
              new Role { Id = 4,Name = "Manager", NormalizedName = "MANAGER"},
              new Role { Id = 5,Name = "Guest", NormalizedName = "GUEST"}
            };
            builder.Entity<Role>().HasData(roles);

            var faculties = new[]
            {
                new Faculty { FacultyId = 1, FacultyName = "Information Tecnology"},
                new Faculty { FacultyId = 2, FacultyName = "Computer Science"},
                new Faculty { FacultyId = 3, FacultyName = "Economics"},
                new Faculty { FacultyId = 4, FacultyName = "Environmental Science"},
                new Faculty { FacultyId = 5, FacultyName = "Psychology"}
            };
            builder.Entity<Faculty>().HasData(faculties);

            var articles = new[]
            {
				//Information Tecnology
                new Article
                {
                    ArticleId = 1,
                    ArticleTitle = "ITArticle01",
                    Faculty = "Information Tecnology",
                    UserID = 7,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 2,
                    ArticleTitle = "ITArticle02",
                    Faculty = "Information Tecnology",
                    UserID = 7,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
                    StatusId = 1,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 3,
                    ArticleTitle = "ITArticle03",
                    Faculty = "Information Tecnology",
                    UserID = 7,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
                    StatusId = 2,
                    AgreeToTerms = true,
                    Public = false
                },
                new Article
                {
                    ArticleId = 4,
                    ArticleTitle = "ITArticle04",
                    Faculty = "Information Tecnology",
                    UserID = 7,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
                    StatusId = 3,
                    AgreeToTerms = true,
                    Public = false
                },
                new Article
                {
                    ArticleId = 5,
                    ArticleTitle = "ITArticle05",
                    Faculty = "Information Tecnology",
                    UserID = 7,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
                    StatusId = 3,
                    AgreeToTerms = true,
                    Public = true
                },
				new Article
				{
					ArticleId = 6,
					ArticleTitle = "ITArticle06",
					Faculty = "Information Tecnology",
					UserID = 8,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 7,
					ArticleTitle = "ITArticle07",
					Faculty = "Information Tecnology",
					UserID = 8,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 8,
					ArticleTitle = "ITArticle08",
					Faculty = "Information Tecnology",
					UserID = 8,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 9,
					ArticleTitle = "ITArticle09",
					Faculty = "Information Tecnology",
					UserID = 8,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 10,
					ArticleTitle = "ITArticle10",
					Faculty = "Information Tecnology",
					UserID = 8,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 11,
					ArticleTitle = "ITArticle11",
					Faculty = "Information Tecnology",
					UserID = 9,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 12,
					ArticleTitle = "ITArticle12",
					Faculty = "Information Tecnology",
					UserID = 9,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 13,
					ArticleTitle = "ITArticle13",
					Faculty = "Information Tecnology",
					UserID = 9,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 14,
					ArticleTitle = "ITArticle14",
					Faculty = "Information Tecnology",
					UserID = 9,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 15,
					ArticleTitle = "ITArticle15",
					Faculty = "Information Tecnology",
					UserID = 9,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 16,
					ArticleTitle = "ITArticle16",
					Faculty = "Information Tecnology",
					UserID = 10,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 17,
					ArticleTitle = "ITArticle17",
					Faculty = "Information Tecnology",
					UserID = 10,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 18,
					ArticleTitle = "ITArticle18",
					Faculty = "Information Tecnology",
					UserID = 10,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 19,
					ArticleTitle = "ITArticle19",
					Faculty = "Information Tecnology",
					UserID = 10,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 20,
					ArticleTitle = "ITArticle20",
					Faculty = "Information Tecnology",
					UserID = 10,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 21,
					ArticleTitle = "ITArticle21",
					Faculty = "Information Tecnology",
					UserID = 11,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 22,
					ArticleTitle = "ITArticle22",
					Faculty = "Information Tecnology",
					UserID = 11,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 23,
					ArticleTitle = "ITArticle23",
					Faculty = "Information Tecnology",
					UserID = 11,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 24,
					ArticleTitle = "ITArticle24",
					Faculty = "Information Tecnology",
					UserID = 11,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 25,
					ArticleTitle = "ITArticle25",
					Faculty = "Information Tecnology",
					UserID = 11,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},

				//Computer Science
				new Article
				{
					ArticleId = 26,
					ArticleTitle = "CSArticle01",
					Faculty = "Computer Science",
					UserID = 12,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 27,
					ArticleTitle = "CSArticle02",
					Faculty = "Computer Science",
					UserID = 12,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 28,
					ArticleTitle = "CSArticle03",
					Faculty = "Computer Science",
					UserID = 12,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 29,
					ArticleTitle = "CSArticle04",
					Faculty = "Computer Science",
					UserID = 12,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 30,
					ArticleTitle = "CSArticle05",
					Faculty = "Computer Science",
					UserID = 12,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 31,
					ArticleTitle = "CSArticle06",
					Faculty = "Computer Science",
					UserID = 13,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 32,
					ArticleTitle = "CSArticle07",
					Faculty = "Computer Science",
					UserID = 13,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 33,
					ArticleTitle = "CSArticle08",
					Faculty = "Computer Science",
					UserID = 13,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 34,
					ArticleTitle = "CSArticle09",
					Faculty = "Computer Science",
					UserID = 13,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 35,
					ArticleTitle = "CSArticle10",
					Faculty = "Computer Science",
					UserID = 13,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 36,
					ArticleTitle = "CSArticle11",
					Faculty = "Computer Science",
					UserID = 14,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 37,
					ArticleTitle = "CSArticle12",
					Faculty = "Computer Science",
					UserID = 14,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 38,
					ArticleTitle = "CSArticle13",
					Faculty = "Computer Science",
					UserID = 14,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 39,
					ArticleTitle = "CSArticle14",
					Faculty = "Computer Science",
					UserID = 14,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 40,
					ArticleTitle = "CSArticle15",
					Faculty = "Computer Science",
					UserID = 14,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 41,
					ArticleTitle = "CSArticle16",
					Faculty = "Computer Science",
					UserID = 15,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 42,
					ArticleTitle = "CSArticle17",
					Faculty = "Computer Science",
					UserID = 15,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 43,
					ArticleTitle = "CSArticle18",
					Faculty = "Computer Science",
					UserID = 15,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 44,
					ArticleTitle = "CSArticle19",
					Faculty = "Computer Science",
					UserID = 15,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 45,
					ArticleTitle = "CSArticle20",
					Faculty = "Computer Science",
					UserID = 15,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 46,
					ArticleTitle = "CSArticle21",
					Faculty = "Computer Science",
					UserID = 16,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:36.8959251 +07:00"),
					StatusId = 0,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 47,
					ArticleTitle = "CSArticle22",
					Faculty = "Computer Science",
					UserID = 16,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:52.6334713 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:52.6334770 +07:00"),
					StatusId = 1,
					AgreeToTerms = true,
					Public = true
				},
				new Article
				{
					ArticleId = 48,
					ArticleTitle = "CSArticle23",
					Faculty = "Computer Science",
					UserID = 16,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:59.7223506 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-30 20:11:59.7223572 +07:00"),
					StatusId = 2,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 49,
					ArticleTitle = "CSArticle24",
					Faculty = "Computer Science",
					UserID = 16,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:11.4871948 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:11.4872005 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = false
				},
				new Article
				{
					ArticleId = 50,
					ArticleTitle = "CSArticle25",
					Faculty = "Computer Science",
					UserID = 16,
					CreatedDate = DateTimeOffset.Parse("2024-04-02 20:12:24.2273664 +07:00"),
					ExpireDate = DateTimeOffset.Parse("2024-04-16 20:12:24.2273751 +07:00"),
					StatusId = 3,
					AgreeToTerms = true,
					Public = true
				},
			};
            builder.Entity<Article>().HasData(articles);
        }
    }
}
