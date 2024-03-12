using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EduPost.Models;

namespace EduPost.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EduPost.Models.Faculty> Faculty { get; set; } = default!;
        public DbSet<EduPost.Models.Role> Role { get; set; } = default!;
    }
}
