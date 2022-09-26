using RestSharp;
using TimeWebAttendanceEvaluation.Model;
namespace TimeWebAttendanceEvaluation.Infrastructure.Service
{
    public interface IAttendanceService
    {
        public RestResponse Request(string domain, string endpoint, Dictionary<string, string> body = null);
        public List<Evento> RequestEventos(int UsuarioId, string date);
        public Usuario RequestUser(int UsuarioId);
    }
}
