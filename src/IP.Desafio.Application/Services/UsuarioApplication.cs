using IP.Desafio.Application.Interfaces;
using IP.Desafio.Application.Models;
using IP.Desafio.Domain.Users.Models;
using Microsoft.Extensions.Logging;
using System;

namespace IP.Desafio.Application.Services
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly ILogger<UsuarioApplication> _logger;
        public UsuarioApplication(ILogger<UsuarioApplication> logger)
        {
            _logger = logger;
        }

        public bool Criar(UsuarioViewModel model)
        {
            try
            {
                var usuario = new Usuario(new Guid(), model.Nome, model.Senha);

                usuario.ValidarSenha();

                _logger.LogTrace("Senha validada");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}