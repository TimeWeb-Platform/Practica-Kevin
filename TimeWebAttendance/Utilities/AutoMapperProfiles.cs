using AutoMapper;
using TimeWebAttendanceUsers.Entities;
using TimeWebAttendanceUsers.DTO;


namespace TimeWebAttendanceUsers.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioCDTO>().ReverseMap();
        }
    }
}
