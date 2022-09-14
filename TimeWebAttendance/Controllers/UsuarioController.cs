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
        public UsuarioController(ISUsuario context) 
        {
            this.context = context;
        }
        //GET
        #region
        [HttpGet(Name = "getUsers")]
        public async Task<ActionResult> Get()
        {
            return Ok(await context.GetUser());
        }

        [HttpGet("{id}",Name = "getUser")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await context.GetUserById(id));
        }
        #endregion
        //POST
        //PUT
        //PATCH
        //DELETE
    }
}
