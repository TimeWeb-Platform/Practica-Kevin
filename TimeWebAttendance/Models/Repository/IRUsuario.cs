using TimeWebAttendanceUsers.Entities;

namespace TimeWebAttendanceUsers.Models.Repository
{
    public interface IRUsuario
    {
        Task<List<Usuario>> GetUser();
        Task<Usuario?> GetUserById(int id);
        Task<Usuario> InsertUser(Usuario user);
        Task<Usuario> UpdateUser(Usuario user);
        Task<Usuario> RemoveUser(Usuario user);
        public Task<bool> Exists(int id);
        Task Save();

    }
}
