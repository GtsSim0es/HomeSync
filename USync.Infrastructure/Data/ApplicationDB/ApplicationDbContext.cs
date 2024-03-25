using USync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace USync.Infrastructure.Data.ApplicationDB
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileRule> ProfileRules { get; set; }
    }
}
