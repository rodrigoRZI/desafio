using IP.Desafio.Domain.Users.ValueObjects;
using System;

namespace IP.Desafio.Domain.Users.Models
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Senha Senha { get; private set; }

        public Usuario(Guid id, string nome, string senha)
        {
            Id = id;
            Nome = nome;
            Senha = new Senha(senha);
        }

        public void ValidarSenha()
        {
            Senha.Validar();
        }
    }
}
