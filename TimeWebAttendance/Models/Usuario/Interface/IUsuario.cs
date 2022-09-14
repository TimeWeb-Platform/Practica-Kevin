using TimeWebAttendanceUsers.DTO;

namespace TimeWebAttendanceUsers.Models.Usuario.Interface
{
    public interface IUsuario
    {
        List<UsuarioDTO> GetUser();
        UsuarioDTO GetUserById(int id);
        void InsertUser(UsuarioCDTO user);
        void UpdateUser(UsuarioCDTO user);
        void DeleteUser(int id);
        void SaveChanges();
    }
}
