using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TimeWebAttendanceEvents.Infrastructure.Service;
using TimeWebAttendanceEvents.DTO;
using TimeWebAttendanceEvents.Model;
using System.Net;

namespace TimeWebAttendanceEvents.Controllers
{
    [Route("api/evento")]
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
        [HttpGet("userid/{id}/{date}")]
        public async Task<ActionResult> GetEventsByUser(int id, string date)
        {
            var userEvents = await context.GetEventByUserId(id, date);
            if (userEvents.Count == 0)
            {
                return NoContent();
            }
            return Ok(userEvents);
        }
        //POST
        [HttpPost]
        public async Task<ActionResult> Post(EventoCDTO newEventdto)
        {
            //request a Usuario
            HttpStatusCode request = context.RequestUsuarioId(newEventdto.UsuarioId);
            if (request.Equals(HttpStatusCode.NotFound))
                return BadRequest();
            //Fecha del registro
            var newEvent = mapper.Map<Evento>(newEventdto);
            newEvent.FechaAlta = DateTime.Now;
            //Save into DB
            await context.InsertEvent(newEvent);
            return NoContent();
        }
    }
}
