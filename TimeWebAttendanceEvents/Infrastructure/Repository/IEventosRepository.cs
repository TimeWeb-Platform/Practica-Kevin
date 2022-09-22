using TimeWebAttendanceEvents.Model;

namespace TimeWebAttendanceEvents.Infrastructure.Repository
{
    public interface IEventosRepository
    {
        Task<List<Evento>> GetEvent();
        Task<Evento?> GetEventById(int id);
        Task<Evento> InsertEvent(Evento evento);
    }
}
