using TimeWebAttendanceEvents.Model;
namespace TimeWebAttendanceEvents.Infrastructure.Service
{
    public interface IEventosService
    {
        Task<List<Evento>> GetEvent();
        Task<Evento?> GetEventById(int id);
        Task<Evento> InsertEvent(Evento evento);
    }
}
