using HomeSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeSync.Infrastructure.Data.ApplicationDB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileRule> ProfileRules { get; set; }
    }
}
