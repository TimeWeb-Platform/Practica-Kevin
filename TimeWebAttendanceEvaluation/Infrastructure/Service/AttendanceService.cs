using TimeWebAttendanceEvaluation.Infrastructure.Repository;
using RestSharp;
using TimeWebAttendanceEvaluation.Model;
using System.Linq;
using Newtonsoft.Json;
using System.Net;
using TimeWebAttendanceEvaluation.Infrastructure.Strategy;
using TimeWebAttendanceEvaluation.DTO;

namespace TimeWebAttendanceEvaluation.Infrastructure.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository repository;
        public AttendanceService(IAttendanceRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<Attendance>> GetAttendance()
        {
            return await repository.GetAttendance();
        }
        public List<Evento> RequestEventos(int UsuarioId, string date)
        {
            var response = Request("https://localhost:7136", $"/api/evento/userid/{UsuarioId}/{date}");
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return null;
            return JsonConvert.DeserializeObject<List<Evento>>(response.Content);
        }
        public int RequestRazonSocial(int UsuarioId)
        {
            var response = Request("https://localhost:7084", $"/api/usuario/{UsuarioId}");
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return -1;
            var user =  JsonConvert.DeserializeObject<Usuario>(response.Content);
            return user.RazonSocialId;
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

        public List<AttendanceDTO> Evaluate(List<Evento> eventos, int RazonSocial,string date)
        {
            var context = new EvaluateContext();
            var dates = datesList(DateTime.Parse(date));
            switch (RazonSocial)
            {
                case 1:
                    context.SetStrategy(new EvaluateStrategyRS1(repository));
                    break;
                case 2:
                    context.SetStrategy(new EvaluateStrategyRS2(repository));
                    break;
                case 3:
                    context.SetStrategy(new EvaluateStrategyRS3(repository));
                    break;
            }
            return context.Execute(eventos,dates);
        }

        public List<DateTime> datesList(DateTime date)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime tempDate = date.AddDays(-10);
            while(tempDate.Date != date)
            {
                dates.Add(tempDate);
                tempDate = tempDate.AddDays(1).Date;
            }
            return dates;
        }

        
    }
}
