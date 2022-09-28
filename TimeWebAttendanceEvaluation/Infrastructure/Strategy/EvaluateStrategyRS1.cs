 using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Infrastructure.Repository;
using TimeWebAttendanceEvaluation.Model;

namespace TimeWebAttendanceEvaluation.Infrastructure.Strategy
{
    public class EvaluateStrategyRS1 : IEvaluateStrategy
    {
        private readonly IAttendanceRepository repo;

        public EvaluateStrategyRS1(IAttendanceRepository repo)
        {
            this.repo = repo;
        }
        public List<AttendanceDTO> Evaluate(List<Evento> eventos,List<DateTime> dates)
        {
            List<DateTime> eventDates = EventDates(eventos);
            List<AttendanceDTO> eval = new List<AttendanceDTO>();
            foreach (var day in dates)
            {
                AttendanceDTO dailyAttendance = new AttendanceDTO
                {
                    UsuarioId = eventos[0].UsuarioId,
                    Fecha = day
                };
                if (ExistEvent(eventDates,day))
                    dailyAttendance.Asistencia = true;
                else
                    dailyAttendance.Asistencia = false;
                repo.SetAttendance(dailyAttendance);
                eval.Add(dailyAttendance);
            }
            return eval;
        }
        public bool ExistEvent(List<DateTime> events, DateTime day)
        {
            DateTime start = day.AddHours(20);
            DateTime end = start.AddHours(6);
            int count = events.Where(x => x >= start && x <= end).Count(); 
            if (count >= 1)
            {
                return true;
            }
            return false;
        }
        public List<DateTime> EventDates(List<Evento> eventos)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach(var date in eventos)
            {
                dates.Add(date.FechaAlta);
            }
            return dates;
        }
    }
}
