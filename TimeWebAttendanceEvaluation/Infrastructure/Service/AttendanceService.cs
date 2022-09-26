using TimeWebAttendanceEvaluation.Infrastructure.Repository;
using RestSharp;
using TimeWebAttendanceEvaluation.Model;
using System.Linq;
using Newtonsoft.Json;
using System.Net;

namespace TimeWebAttendanceEvaluation.Infrastructure.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository repository;
        public AttendanceService(IAttendanceRepository repository)
        {
            this.repository = repository;
        }
        public List<Evento> RequestEventos(int UsuarioId, string date)
        {
            var response = Request("https://localhost:7136", $"/api/evento/userid/{UsuarioId}",
                new Dictionary<string, string>() { { "date", date } });
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return null;
            return JsonConvert.DeserializeObject<List<Evento>>(response.Content);
        }
        public Usuario RequestUser(int UsuarioId)
        {
            var response = Request("https://localhost:7084", $"/api/usuario/{UsuarioId}");
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return null;
            return JsonConvert.DeserializeObject<Usuario>(response.Content);
        }
        public RestResponse Request(string domain, string endpoint, Dictionary<string,string> body = null)
        {
            var options = new RestClientOptions(domain)
            {
                ThrowOnAnyError = true
            };
            var client = new RestClient(options);
            var request = new RestRequest(endpoint);
            request.RequestFormat = DataFormat.Json;
            if (body != null)
                request.AddJsonBody(body);
            return client.Execute(request);
        }
    }
}
