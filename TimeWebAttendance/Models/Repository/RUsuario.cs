using Microsoft.EntityFrameworkCore;
using TimeWebAttendanceUsers.DTO;
using TimeWebAttendanceUsers.Entities;

namespace TimeWebAttendanceUsers.Models.Repository
{
    public class RUsuario : IRUsuario
    {
        private readonly ApplicationDbContext context;

        public RUsuario(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuario>> GetUser()
        {
            return await context.Usuario.ToListAsync();
        }

        public async Task<Usuario?> GetUserById(int id)
        {
            return await context.Usuario.FirstOrDefaultAsync();
        }

        public async Task<Usuario> InsertUser(Usuario user)
        {
            context.Usuario.Add(user);
            await context.SaveChangesAsync();
            return user;

        }

        public async void RemoveUser(Usuario user)
        {
            context.Usuario.Remove(user);
            await context.SaveChangesAsync();
        }

        public void UpdateUser(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
