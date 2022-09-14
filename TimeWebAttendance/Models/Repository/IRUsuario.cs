using TimeWebAttendanceUsers.Entities;

namespace TimeWebAttendanceUsers.Models.Repository
{
    public interface IRUsuario
    {
        Task<List<Usuario>> GetUser();
        Task<Usuario?> GetUserById(int id);
        Task<Usuario> InsertUser(Usuario user);
        void UpdateUser(Usuario user);
        void RemoveUser(Usuario user);
        
    }
}
