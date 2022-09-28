using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeWebAttendanceEvaluation.Infrastructure.Service;

namespace TimeWebAttendanceEvaluation.Controllers
{
    [Route("api/evaluacion")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {
        private readonly IAttendanceService attendance;

        public EvaluacionController(IAttendanceService attendance)
        {
            this.attendance = attendance;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await attendance.GetAttendance());
        }
        [HttpGet("{id:int}/{date}")]
        public async Task<ActionResult> EvaluarUsuario(int id, string date)
        {
            //Request a Evento
            var eventos = attendance.RequestEventos(id, date);
            if (eventos == null)
                return BadRequest("There are no Events for that User");
            //Request a User
            int razonSocial = attendance.RequestRazonSocial(id);
            if (razonSocial == -1)
                return BadRequest("This User doesnt Exist");
            //Evaluamos
            return Ok(attendance.Evaluate(eventos, razonSocial, date));
        }
    }
}
