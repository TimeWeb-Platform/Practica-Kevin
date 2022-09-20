using AutoMapper;
using Moq;
using TimeWebAttendanceUsers.Controllers;
using TimeWebAttendanceUsers.Models.Repository;
using TimeWebAttendanceUsers.Models.Service;
using TimeWebAttendanceUsers.Entities;
using TimeWebAttendanceUsers.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TimeWebAttendanceUsers.Tests
{
    public class UsuarioControllerTests

    {
        private readonly ApplicationDbContext context;
        

        [Fact]
        public async Task Get_UsuariosList_OkAsync()
        {
            //Arrange
            //auto mapper configuration      
            var mapper = new Mock<IMapper>();
            var mockProfile = new Mock<Profile>();
            mockProfile.Setup(x => x.CreateMap<Usuario, UsuarioCDTO>().ReverseMap());
            mapper.Setup(x => x.Map<Usuario>(It.IsAny<UsuarioCDTO>()));
            var repo = new RUsuario(context);  
            var service = new SUsuario(repo);
            var client = new UsuarioController(service, mapper);
            var usuario = new Usuario(0, "Kevin", "Ramirez", "Mendez", DateTime.Now, 3);
            //Act
            await client.Post(usuario);
            var response = await client.Get();
            //Assert
            var contentResponse = Assert.IsType<OkObjectResult>(response);

            Assert.Single(contentResponse.Value.As<List<Usuario>>());
        }
    }
}