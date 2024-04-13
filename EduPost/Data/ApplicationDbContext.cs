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
                },
                new User
                {
                    Id = 7,
                    UserName = "ITUser@email.com",
                    Email = "ITUser@email.com",
                    Faculty = "Information Tecnology",
                    Role = "User",
                    NormalizedUserName = "ITUSER@EMAIL.COM",
                    NormalizedEmail = "ITUSER@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEH+sZz3bFv5Wywum0wvsGfPWHcHzrU1eP3NFCsZgCv+i4iLsX/hbwo5UAoa5DXEY1Q==",
                    SecurityStamp = "KL4GXYEBVQCM4CMOUHUWGVA76X5GWPLK",
                    ConcurrencyStamp = "eb09b0fb-ec00-493a-922a-dac179910c75",
                    LockoutEnabled = true,
                },
                new User
                {
                    Id = 8,
                    UserName = "CSUser@email.com",
                    Email = "CSUser@email.com",
                    Faculty = "Computer Science",
                    Role = "User",
                    NormalizedUserName = "CSUSER@EMAIL.COM",
                    NormalizedEmail = "CSUSER@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEC2lBMmzn9Yz4SZc01Pp0gtWDaUXyEYFQkFmprsa93UzlO5IoXSktJ6WnO2wfzBAtw==",
                    SecurityStamp = "YO6SY4A2FLBOS7ZHD4GRYTXZTKCD4JOM",
                    ConcurrencyStamp = "53038d4e-7b6d-4185-8e7f-2415763a63d5",
                    LockoutEnabled = true,
                },
                new User
                {
                    Id = 9,
                    UserName = "EUser@email.com",
                    Email = "EUser@email.com",
                    Faculty = "Economics",
                    Role = "User",
                    NormalizedUserName = "EUSER@EMAIL.COM",
                    NormalizedEmail = "EUSER@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEJo3QDCo6vtJ6l1GW3RaXbYL0+jKR+Tp8/x+Ny1VoAJhh/Mb2c+JOEA3MF0K68wkUg==",
                    SecurityStamp = "7ASQ2UGT33TIBBIGWOHIZRSTT3ZZWSHA",
                    ConcurrencyStamp = "5288bb02-53b6-47cf-9da5-a21eb80b3b13",
                    LockoutEnabled = true,
                },
                new User
                {
                    Id = 10,
                    UserName = "ESUser@email.com",
                    Email = "ESUser@email.com",
                    Faculty = "Environmental Science",
                    Role = "User",
                    NormalizedUserName = "ESUSER@EMAIL.COM",
                    NormalizedEmail = "ESUSER@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAECmJwOOIUtxINztEbzdBGoIv8vic33hW/XaXWx524PnHCzAq0+r9h8qXWflV9dAreA==",
                    SecurityStamp = "ZDEUN3C3CICWEQN6KH4AI3UFWJCWGA5A",
                    ConcurrencyStamp = "893122b9-115a-41c3-b526-fc7cda035a6b",
                    LockoutEnabled = true,
                },
                new User
                {
                    Id = 11,
                    UserName = "PsyUser@email.com",
                    Email = "PsyUser@email.com",
                    Faculty = "Psychology",
                    Role = "User",
                    NormalizedUserName = "PSYUSER@EMAIL.COM",
                    NormalizedEmail = "PSYUSER@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAELRnJOAVIaxsmhQAwr4S4MghTgxv8ZKuJVGGcIhRaHb55dkpwnwYC86GlM9qGthE4A==",
                    SecurityStamp = "XCVBJEVYK3X2AO3N26IMH2LTVOXNPWEN",
                    ConcurrencyStamp = "99b4129c-6f43-4332-80e8-1abfd403d54f",
                    LockoutEnabled = true,
                },
                new User
                {
                    Id = 12,
                    UserName = "Manager@email.com",
                    Email = "Manager@email.com",
                    Faculty = "Information Tecnology",
                    Role = "User",
                    NormalizedUserName = "MANAGER@EMAIL.COM",
                    NormalizedEmail = "MANAGER@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEM+mPvVomCRp2EY60mU1dycFTYnWTmGIzkvnWy1R47/zs5zd9zIrRO2uDgX/wJoJmw==",
                    SecurityStamp = "OK5EHYUMTYTQDEY5FHJVZMIYUYUYXMP2",
                    ConcurrencyStamp = "f2a383ab-3759-4516-9107-fd7b075d1f23",
                    LockoutEnabled = true,
                },
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
                new IdentityUserRole<int> { UserId = 12, RoleId = 4 },
            };
            builder.Entity<IdentityUserRole<int>>().HasData(userRolePairs);

            var roles = new[]
            { 
              new Role { Id = 1,Name = "Admin", NormalizedName = "ADMIN"},
              new Role { Id = 2,Name = "User", NormalizedName = "USER"},
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
                new Article
                {
                    ArticleId = 1,
                    ArticleTitle = "ITArticle01",
                    Faculty = "Information Tecnology",
                    UserID = 7,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:11:36.8958253 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:11:36.8959251 +07:00"),
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
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:11:52.6334770 +07:00"),
                    StatusId = 0,
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
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:11:59.7223572 +07:00"),
                    StatusId = 0,
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
                    StatusId = 0,
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
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 6,
                    ArticleTitle = "CSArticle01",
                    Faculty = "Computer Science",
                    UserID = 8,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:13:42.7804099 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:13:42.7804158 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 7,
                    ArticleTitle = "CSArticle02",
                    Faculty = "Computer Science",
                    UserID = 8,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:13:50.6394727 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:13:50.6394775 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = false
                },
                new Article
                {
                    ArticleId = 8,
                    ArticleTitle = "CSArticle03",
                    Faculty = "Computer Science",
                    UserID = 8,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:14:01.5860277 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:14:01.5860327 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 9,
                    ArticleTitle = "CSArticle04",
                    Faculty = "Computer Science",
                    UserID = 8,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:14:11.9552979 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:14:11.9553029 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 10,
                    ArticleTitle = "EArticle01",
                    Faculty = "Economics",
                    UserID = 9,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:15:00.9357115 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:15:00.9357182 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 11,
                    ArticleTitle = "EArticle02",
                    Faculty = "Economics",
                    UserID = 9,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:15:07.7677437 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:15:07.7677483 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = false
                },
                new Article
                {
                    ArticleId = 12,
                    ArticleTitle = "EArticle03",
                    Faculty = "Economics",
                    UserID = 9,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:15:16.4221925 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:15:16.4221982 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 13,
                    ArticleTitle = "ESArticle01",
                    Faculty = "Environmental Science",
                    UserID = 10,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:15:41.5915518 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:15:41.5915631 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 14,
                    ArticleTitle = "ESArticle02",
                    Faculty = "Environmental Science",
                    UserID = 10,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:15:50.4288359 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:15:50.4288402 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
                new Article
                {
                    ArticleId = 15,
                    ArticleTitle = "PsyArticle01",
                    Faculty = "Psychology",
                    UserID = 11,
                    CreatedDate = DateTimeOffset.Parse("2024-04-02 20:16:26.6760365 +07:00"),
                    ExpireDate = DateTimeOffset.Parse("2024-04-16 20:16:26.6760431 +07:00"),
                    StatusId = 0,
                    AgreeToTerms = true,
                    Public = true
                },
            };
            builder.Entity<Article>().HasData(articles);
        }
    }
}
