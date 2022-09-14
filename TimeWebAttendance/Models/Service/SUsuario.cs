using TimeWebAttendanceUsers.DTO;
using TimeWebAttendanceUsers.Entities;
using TimeWebAttendanceUsers.Models.Repository;

namespace TimeWebAttendanceUsers.Models.Service
{
    public class SUsuario : ISUsuario
    {
        private readonly IRUsuario userRepo;

        public SUsuario(IRUsuario userRepo)
        {
            this.userRepo = userRepo; 
        }
        public async Task<List<Usuario>> GetUser()
        {
            return await userRepo.GetUser();
        }

        public async Task<Usuario?> GetUserById(int id)
        {
            return await userRepo.GetUserById(id);  
        }

        public Task<Usuario> InsertUser(Usuario user)
        {
            return userRepo.InsertUser(user);
        }

        public void RemoveUser(int id)
        {

            throw new NotImplementedException();
        }

        public void UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
