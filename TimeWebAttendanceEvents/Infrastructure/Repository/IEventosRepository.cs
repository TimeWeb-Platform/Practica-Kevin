using TimeWebAttendanceEvents.Model;

namespace TimeWebAttendanceEvents.Infrastructure.Repository
{
    public interface IEventosRepository
    {
        Task<List<Evento>> GetEvent();
        Task<Evento?> GetEventById(int id);
        Task<List<Evento?>> GetEventByUserId(int UsuarioId);
        Task<Evento> InsertEvent(Evento evento);
    }
}
