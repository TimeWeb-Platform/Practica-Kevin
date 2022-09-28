using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Model;

namespace TimeWebAttendanceEvaluation.Infrastructure.Strategy
{
    public interface IEvaluateStrategy
    {
        public List<AttendanceDTO> Evaluate(List<Evento> eventos, List<DateTime> dates);
    }
}
