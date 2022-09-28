using AutoMapper;
using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Model;
using Microsoft.EntityFrameworkCore;

namespace TimeWebAttendanceEvaluation.Infrastructure.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AttendanceRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<Attendance>> GetAttendance()
        {
            return await context.Attendance.ToListAsync();
        }

        public async Task<Attendance> SetAttendance(AttendanceDTO attendancedto )
        {
            var attendance = mapper.Map<Attendance>(attendancedto);
            context.Attendance.Add(attendance);
            await context.SaveChangesAsync();
            return attendance;
        }
    }
}
