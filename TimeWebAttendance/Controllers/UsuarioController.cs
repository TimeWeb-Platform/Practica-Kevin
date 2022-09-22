using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TimeWebAttendanceUsers.Entities;
using TimeWebAttendanceUsers.Models.Service;
using TimeWebAttendanceUsers.DTO;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<ActionResult> Get()
        {
            return Ok(await context.GetUser());
        }

        [HttpGet("{id}",Name = "getUser")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await context.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        #endregion
        //POST
        [HttpPost]
        public async Task<ActionResult> Post(UsuarioCDTO newUser)
        {

            await context.InsertUser(mapper.Map<Usuario>(newUser));
            return Ok();
        }
        //PUT
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(UsuarioCDTO modifiedUser, int id)
        {
            if (!context.Exists(id).Result) return NotFound();
            var map = mapper.Map<Usuario>(modifiedUser);
            map.Id = id;
            await context.UpdateUser(map);
            return Ok();
        }
        //PATCH
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<UsuarioPDTO> patchDoc)
        {
            if (patchDoc == null) { return BadRequest("Patch Document null"); }
            var user = await context.GetUserById(id);
            if (user == null) { return NotFound(); }

            var userToPatch = mapper.Map<UsuarioPDTO>(user);

            patchDoc.ApplyTo(userToPatch);

            var validoactor = TryValidateModel(userToPatch);
            if (!validoactor) { return BadRequest(ModelState); }

            mapper.Map(userToPatch, user);
            await context.Save();

            return NoContent();


        }
        //DELETE
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!context.Exists(id).Result) return NotFound();
            var user = context.GetUserById(id).Result;
            await context.RemoveUser(user);
            return Ok();
        }
    }
}
