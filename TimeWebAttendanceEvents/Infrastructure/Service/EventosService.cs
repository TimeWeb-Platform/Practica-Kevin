using TimeWebAttendanceEvents.Infrastructure.Repository;
using TimeWebAttendanceEvents.Model;
using RestSharp;
using System.Net;

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
        public Task<List<Evento?>> GetEventByUserId(int UsuarioId)
        {
            return repository.GetEventByUserId(UsuarioId);
        }

        public Task<Evento> InsertEvent(Evento evento)
        {
            return repository.InsertEvent(evento);
        }
        public HttpStatusCode RequestUsuarioId(int id)
        {
            var options = new RestClientOptions("https://localhost:7084")
            {
                ThrowOnAnyError = true
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/api/usuario/{id}");
            var response = client.Execute(request);
            return response.StatusCode;
        }
    }
}
