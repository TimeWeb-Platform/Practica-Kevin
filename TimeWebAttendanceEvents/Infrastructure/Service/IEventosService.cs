using TimeWebAttendanceEvents.Model;
using System.Net;
namespace TimeWebAttendanceEvents.Infrastructure.Service
{
    public interface IEventosService
    {
        Task<List<Evento>> GetEvent();
        Task<Evento?> GetEventById(int id);
        Task<List<Evento?>> GetEventByUserId(int UsuarioId);
        Task<Evento> InsertEvent(Evento evento);
        HttpStatusCode RequestUsuarioId(int id);
    }
}
