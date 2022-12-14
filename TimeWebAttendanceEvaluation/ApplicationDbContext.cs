using TimeWebAttendanceEvaluation.Model;
using Microsoft.EntityFrameworkCore;
namespace TimeWebAttendanceEvaluation
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

        public DbSet<Attendance> Attendance { get; set; }
    }
}
