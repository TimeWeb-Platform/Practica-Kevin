using AutoMapper;
using TimeWebAttendanceEvents.DTO;
using TimeWebAttendanceEvents.Model;
namespace TimeWebAttendanceEvents.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDTO>().ReverseMap();
            CreateMap<Evento, EventoCDTO>().ReverseMap();

        }
    }
}
