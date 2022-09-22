using TimeWebAttendanceEvents.Infrastructure.Repository;
using TimeWebAttendanceEvents.Model;

namespace TimeWebAttendanceEvents.Infrastructure.Service
{
    public class EventosService : IEventosService
    {
        private readonly IEventosRepository repository;
        public EventosService(IEventosRepository repository)
        {
            this.repository = repository;
        }
        public Task<List<Evento>> GetEvent()
        {
            return repository.GetEvent();
        }

        public Task<Evento?> GetEventById(int id)
        {
            return repository.GetEventById(id);
        }

        public Task<Evento> InsertEvent(Evento evento)
        {
            return repository.InsertEvent(evento);
        }
    }
}
