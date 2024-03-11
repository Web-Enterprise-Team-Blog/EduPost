using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduPost.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EduPost.Models.User>? User { get; set; }
        public DbSet<EduPost.Models.Role>? Role { get; set; }
        public DbSet<EduPost.Models.Article>? Article { get; set; }
        public DbSet<EduPost.Models.Faculty>? Faculty { get; set; }
        public DbSet<EduPost.Models.Status>? Status { get; set; }
    }
}
