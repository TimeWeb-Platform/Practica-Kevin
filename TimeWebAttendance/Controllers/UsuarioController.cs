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
        private readonly Mapper mapper;

        public UsuarioController(ISUsuario context, Mapper mapper) 
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
            return Ok(await context.GetUserById(id));
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
        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] JsonPatchDocument<UsuarioPDTO> modUser, int id)
        {
            if (modUser == null) { return BadRequest("se esperaba actor Patch"); }
            var user = await context.GetUserById(id);
            if (user == null) { return NotFound(); }

            var userdb = mapper.Map<UsuarioPDTO>(user);

            modUser.ApplyTo(userdb, ModelState);

            var validoactor = TryValidateModel(mapActor);
            if (!validoactor) { return BadRequest(ModelState); }

            mapper.Map(mapActor, actordb);
            //////
            var result = await context.SaveChangesAsync();
            if (result > 0) { return Ok(); }
            //////
            return BadRequest("no se lograron editar los datos");


        }
        //DELETE
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!context.Exists(id).Result) return NotFound();
            var user = context.GetUserById(id).Result;
            await context.UpdateUser(user);
            return Ok();
        }
    }
}
