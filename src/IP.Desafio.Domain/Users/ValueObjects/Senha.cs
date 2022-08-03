using System;
using IP.Desafio.Domain.Core.ExtensionMethods;

namespace IP.Desafio.Domain.Users.ValueObjects
{
    public class Senha
    {
        public string Valor { get; private set; }

        public Senha(string valor)
        {
            Valor = valor;
        }

        public void Validar()
        {
            ValidarQuantidadeCaractere();
            ValidarCaractereEspecial();
            ValidarLetraMinuscula();
            ValidarLetraMaiuscula();
            ValidarCaractereRepetido();
        }

        private void ValidarQuantidadeCaractere()
        {
            if (Valor.Length < 9)
                throw new ArgumentException("Senha - Necessário ao menos 9 caracteres");
        }

        private void ValidarCaractereEspecial()
        {
            if (!Valor.IsSpecialCharacter())
                throw new ArgumentException("Senha - Necessário ao menos 1 caractere especial");
        }

        private void ValidarLetraMinuscula()
        {
            if (!Valor.IsLower())
                throw new ArgumentException("Senha - Necessário ao menos 1 letra minúscula");
        }

        private void ValidarLetraMaiuscula()
        {
            if (!Valor.IsUpper())
                throw new ArgumentException("Senha - Necessário ao menos 1 letra maiúscula");
        }

        private void ValidarCaractereRepetido()
        {
            if (Valor.IsRepeatedCharacter())
                throw new ArgumentException("Senha - Necessário não possuir caracteres repetidos dentro do conjunto");
        }
    }
}