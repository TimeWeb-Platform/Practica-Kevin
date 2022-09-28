using AutoMapper;
using TimeWebAttendanceEvaluation.DTO;
using TimeWebAttendanceEvaluation.Model;
namespace TimeWebAttendanceEvaluation.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Attendance, AttendanceDTO>().ReverseMap();

        }
    }
}
