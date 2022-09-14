using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TimeWebAttendanceUsers.Entities;
using TimeWebAttendanceUsers.Models.Service;
using TimeWebAttendanceUsers.DTO;

namespace TimeWebAttendanceUsers.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ISUsuario context;
        private readonly IMapper mapper;
        public UsuarioController(ISUsuario context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }
        //GET
        #region
        [HttpGet(Name = "getUsers")]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            return mapper.Map<List<UsuarioDTO>>(await context.GetUser());
        }

        [HttpGet("{id}",Name = "getUser")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            return mapper.Map<UsuarioDTO>(await context.GetUserById(id));
        }
        #endregion
        //POST
        //PUT
        //PATCH
        //DELETE
    }
}
