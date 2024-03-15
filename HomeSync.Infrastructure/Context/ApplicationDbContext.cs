using Microsoft.EntityFrameworkCore;

namespace HomeSync.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<LogEventos> Users { get; set; }
    }
}
