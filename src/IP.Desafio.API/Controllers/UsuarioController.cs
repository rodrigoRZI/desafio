using IP.Desafio.Application.Interfaces;
using IP.Desafio.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace IP.Desafio.Api.Controllers
{
    [Produces("application/json")]
    [Route("ip-desafio/v1/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioApplication usuarioApplication, ILogger<UsuarioController> logger)
        {
            _usuarioApplication = usuarioApplication;
            _logger = logger;
        }

        public IActionResult Post([FromBody] UsuarioViewModel model)
        {
            try
            {
                _usuarioApplication.Criar(model);
                return StatusCode(201, model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("ArgumentException", model);
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
