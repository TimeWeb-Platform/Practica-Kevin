using Microsoft.EntityFrameworkCore;
using TimeWebAttendanceUsers.Entities;

namespace TimeWebAttendanceUsers
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
