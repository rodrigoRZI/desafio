using IP.Desafio.Api.Controllers;
using IP.Desafio.Application.Interfaces;
using IP.Desafio.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace IP.Desafio.Tests
{
    public class UsuarioControllerTeste
    {
        private readonly UsuarioController _usuarioController;
        private readonly Mock<IUsuarioApplication> _usuarioApplication;
        private readonly Mock<ILogger<UsuarioController>> _logger;

        public UsuarioControllerTeste()
        {
            _usuarioApplication = new Mock<IUsuarioApplication>();
            _logger = new Mock<ILogger<UsuarioController>>();
            _usuarioController = new UsuarioController(_usuarioApplication.Object, _logger.Object);
        }

        [Fact(DisplayName = "Post - Criar Usuário - Sucesso")]
        [Trait("Controller", null)]
        public void Post_CriarUsuario_Sucesso()
        {
            // Arrange
            var model = new UsuarioViewModel()
            {
                Nome = "Jõao",
                Senha = "Senha123@@"
            };

            // Act
            var result = _usuarioController.Post(model);
            var objectResult = result as ObjectResult;

            // Assert
            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Post - Criar Usuário - ArgumentException")]
        [Trait("Controller", null)]
        public void Post_CriarUsuario_ArgumentException()
        {
            // Arrange
            var model = new UsuarioViewModel()
            {
                Nome = "Jõao",
                Senha = "Senha123@@"
            };

            _usuarioApplication.Setup(x => x.Criar(model))
                .Throws<ArgumentException>();

            // Act
            var result = _usuarioController.Post(model);
            var objectResult = result as ObjectResult;

            // Assert
            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Post - Criar Usuário - Exception")]
        [Trait("Controller", null)]
        public void Post_CriarUsuario_Exception()
        {
            // Arrange
            var model = new UsuarioViewModel()
            {
                Nome = "Jõao",
                Senha = "Senha123@@"
            };

            _usuarioApplication.Setup(x => x.Criar(model))
                .Throws<Exception>();

            // Act
            var result = _usuarioController.Post(model);
            var statusResult = result as StatusCodeResult;

            // Assert
            Assert.Equal(500, statusResult.StatusCode);
        }
    }
}