using TimeWebAttendanceEvents.Model;
using Microsoft.EntityFrameworkCore;
namespace TimeWebAttendanceEvents
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Evento> Evento { get; set; }
    }
}
