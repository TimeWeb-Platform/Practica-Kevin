using TimeWebAttendanceUsers.Entities;

namespace TimeWebAttendanceUsers.Models.Service
{
    public interface ISUsuario
    {
        Task<List<Usuario>> GetUser();
        Task<Usuario?> GetUserById(int id);
        Task<Usuario> InsertUser(Usuario user);
        void UpdateUser(int id);
        void RemoveUser(int id);
    }
}
