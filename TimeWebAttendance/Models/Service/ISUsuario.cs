using TimeWebAttendanceUsers.Entities;

namespace TimeWebAttendanceUsers.Models.Service
{
    public interface ISUsuario
    {
        Task<List<Usuario>> GetUser();
        Task<Usuario?> GetUserById(int id);
        Task<Usuario> InsertUser(Usuario user);
        Task UpdateUser(Usuario user);
        Task RemoveUser(Usuario user);
        public Task<bool> Exists(int id);

        Task Save();
    }
}
