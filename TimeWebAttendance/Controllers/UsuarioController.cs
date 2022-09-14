using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TimeWebAttendanceUsers.Entities;
using TimeWebAttendanceUsers.DTO;

namespace TimeWebAttendanceUsers.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public UsuarioController(ApplicationDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }
        //GET
        #region
        #endregion
        //POST
        //PUT
        //PATCH
        //DELETE
    }
}
