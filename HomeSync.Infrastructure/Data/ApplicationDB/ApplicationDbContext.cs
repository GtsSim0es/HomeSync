using HomeSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeSync.Infrastructure.Data.ApplicationDB
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileRule> ProfileRules { get; set; }
    }
}
