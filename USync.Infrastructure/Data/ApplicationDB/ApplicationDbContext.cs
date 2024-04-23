using USync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Flunt.Notifications;

namespace USync.Infrastructure.Data.ApplicationDB
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileRule> ProfileRules { get; set; }
        public DbSet<UserTask> UserTasks {get; set;}
        public DbSet<UserCalendar> UserCalendar {get; set;}

        
    }
}
