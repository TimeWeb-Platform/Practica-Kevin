using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TimeWebAttendanceEvents.Infrastructure.Service;
using TimeWebAttendanceEvents.DTO;
using TimeWebAttendanceEvents.Model;

namespace TimeWebAttendanceEvents.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventosService context;
        private readonly IMapper mapper;

        public EventoController(IEventosService context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //GET
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await context.GetEvent());
        }
        [HttpGet("{id}", Name = "getUser")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await context.GetEventById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        //POST
        //[HttpPost]
        //public async Task<ActionResult> Post(EventoCDTO newUser)
        //{
        //    //request a Usuario

        //    if(request == null)
        //        return BadRequest();
        //    await context.InsertEvent(mapper.Map<Evento>(newUser));
        //    return Ok();
        //}
    }
}
