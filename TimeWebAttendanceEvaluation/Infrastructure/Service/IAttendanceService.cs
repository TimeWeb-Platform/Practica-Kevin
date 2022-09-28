using RestSharp;
using System.Net;
using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Model;
namespace TimeWebAttendanceEvaluation.Infrastructure.Service
{
    public interface IAttendanceService
    {
        public Task<List<Attendance>> GetAttendance();
        public RestResponse Request(string domain, string endpoint, Dictionary<string, string> body = null);
        public List<Evento> RequestEventos(int UsuarioId, string date);
        public int RequestRazonSocial(int UsuarioId);
        public List<AttendanceDTO> Evaluate(List<Evento> eventos, int RazonSocial, string date);
    }
}
