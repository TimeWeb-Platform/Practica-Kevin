using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Model;

namespace TimeWebAttendanceEvaluation.Infrastructure.Strategy
{
    public class EvaluateContext
    {
        private IEvaluateStrategy strategy;

        public EvaluateContext() { }
        public EvaluateContext(IEvaluateStrategy strategy)
        {
            this.strategy = strategy;
        }
        public void SetStrategy(IEvaluateStrategy strategy)
        {
            this.strategy = strategy;
        }
        public List<AttendanceDTO> Execute(List<Evento> eventos, List<DateTime> dates)
        {
            return strategy.Evaluate(eventos,dates);
        }
    }
}
