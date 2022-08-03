using System;
using System.ComponentModel.DataAnnotations;

namespace IP.Desafio.Application.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
