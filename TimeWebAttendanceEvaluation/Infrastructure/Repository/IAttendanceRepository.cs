using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Model;

namespace TimeWebAttendanceEvaluation.Infrastructure.Repository
{
    public interface IAttendanceRepository
    {
        public Task<List<Attendance>> GetAttendance();
        public Task<Attendance> SetAttendance(AttendanceDTO attendancedto);
    }
}
