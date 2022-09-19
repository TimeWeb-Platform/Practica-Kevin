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

        public async Task<Usuario> InsertUser(Usuario user)
        {
            return await userRepo.InsertUser(user);
        }

        public async Task RemoveUser(Usuario user)
        {

            await userRepo.RemoveUser(user);
        }

        public async Task UpdateUser(Usuario user)
        {

            await userRepo.UpdateUser(user);
        }

        public Task<bool> Exists(int id)
        {
            return userRepo.Exists(id);
        }

        public async Task Save()
        {
            await userRepo.Save();
        }
    }
}
