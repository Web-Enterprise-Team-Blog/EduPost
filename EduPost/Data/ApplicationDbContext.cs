using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EduPost.Models;
using System.Data;

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
        public DbSet<EduPost.Models.Faculty> Faculty { get; set; } = default!;
        public DbSet<EduPost.Models.Role> Role { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedAdminUser(builder);
        }

        private void SeedAdminUser(ModelBuilder builder)
        {
            var adminusers = new[]
            {
                new User 
                { 
                    Id = 1, 
                    UserName = "AdminTest",
                    Email = "TestEmail@email.com",
                    FacultyId = 1,
                    RoleId = 1,
                    NormalizedUserName = "ADMINTEST",
                    NormalizedEmail = "TESTEMAIL@EMAIL.COM",
                    EmailConfirmed = true,
                    //Pasword:Admin@01
                    PasswordHash = "AQAAAAIAAYagAAAAEOeiGoBGZzflrpnCe+RN6VHV0k7kEbpLSInaNkS8Nz5kZ5/0eiuzYhJ6f1OCgDnlMA==",
                    SecurityStamp = "N4WB5UFKHKL7A77NYK766NIJDZJVQWIP",
                    ConcurrencyStamp = "9c8dc33b-557d-45e3-89f6-da80099cfb11",
                    LockoutEnabled = true,
                }
            };
            builder.Entity<User>().HasData(adminusers);
        }
    }
}
