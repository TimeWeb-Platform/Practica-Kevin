using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Infrastructure.Repository;
using TimeWebAttendanceEvaluation.Model;

namespace TimeWebAttendanceEvaluation.Infrastructure.Strategy
{
    public class EvaluateStrategyRS2 : IEvaluateStrategy
    {
        private readonly IAttendanceRepository repo;

        public EvaluateStrategyRS2(IAttendanceRepository repo)
        {
            this.repo = repo;
        }
        public List<AttendanceDTO> Evaluate(List<Evento> eventos, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }
    }
}
