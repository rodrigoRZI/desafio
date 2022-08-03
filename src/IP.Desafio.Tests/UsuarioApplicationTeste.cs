using IP.Desafio.Application.Models;
using IP.Desafio.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace IP.Desafio.Tests
{
    public class UsuarioApplicationTeste
    {
        private readonly UsuarioApplication _usuarioApplication;
        private readonly Mock<ILogger<UsuarioApplication>> _logger;

        public UsuarioApplicationTeste()
        {
            _logger = new Mock<ILogger<UsuarioApplication>>();
            _usuarioApplication = new UsuarioApplication(_logger.Object);
        }

        [Fact(DisplayName = "Criar - Criar Usuário - Sucesso")]
        [Trait("Application", null)]
        public void Criar_CriarUsuario_Sucesso()
        {
            // Arrange
            var model = new UsuarioViewModel() { Nome = "João", Senha = "IP@Desafio" };

            // Act
            var result = _usuarioApplication.Criar(model);

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Criar - Criar Usuário - Falha")]
        [Trait("Application", null)]
        public void Criar_CriarUsuario_Falha()
        {
            // Arrange
            var model = new UsuarioViewModel() { Nome = "João", Senha = "IP" };

            // Act
            Action act = () => _usuarioApplication.Criar(model);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
        }
    }
}