using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TimeWebAttendanceEvaluation.Controllers
{
    [Route("api/evaluacion")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {
        public EvaluacionController()
        {

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> EvaluarUsuario(int id, [FromBody] string date)
        {

        }
    }
}
