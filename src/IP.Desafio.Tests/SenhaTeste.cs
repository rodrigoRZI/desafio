using IP.Desafio.Domain.Users.ValueObjects;
using System;
using Xunit;

namespace IP.Desafio.Tests
{
    public class SenhaTeste
    {
        public SenhaTeste() { }

        [Fact(DisplayName = "Validar - Validar Senha - Sucesso")]
        [Trait("Domain", null)]
        public void Validar_ValidarSenha_Sucesso()
        {
            // Arrange
            var valor = "Senha123@";

            // Act
            var senha = new Senha(valor);
            senha.Validar();

            // Assert
            Assert.Equal(senha.Valor, valor);
        }

        [Fact(DisplayName = "ValidarQuantidadeCaracter - Validar Quantidade Caractere - Falha")]
        [Trait("Domain", null)]
        public void Validar_ValidarQuantidadeCaracter_Falha()
        {
            // Arrange
            var valor = "senha";

            // Act
            var senha = new Senha(valor);
            Action act = () => senha.Validar();

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Senha - Necessário ao menos 9 caracteres", exception.Message);
        }

        [Fact(DisplayName = "ValidarCaractereEspecial - Validar Caractere Especial - Falha")]
        [Trait("Domain", null)]
        public void Validar_ValidarCaractereEspecial_Falha()
        {
            // Arrange
            var valor = "senha1234,";

            // Act
            var senha = new Senha(valor);
            Action act = () => senha.Validar();

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Senha - Necessário ao menos 1 caractere especial", exception.Message);
        }

        [Fact(DisplayName = "ValidarLetraMinuscula - Validar Letra Minúscula - Falha")]
        [Trait("Domain", null)]
        public void Validar_ValidarLetraMinuscula_Falha()
        {
            // Arrange
            var valor = "SENHA123@";

            // Act
            var senha = new Senha(valor);
            Action act = () => senha.Validar();

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Senha - Necessário ao menos 1 letra minúscula", exception.Message);
        }

        [Fact(DisplayName = "ValidarLetraMaiuscula - Validar Letra Maiúscula - Falha")]
        [Trait("Domain", null)]
        public void Validar_ValidarLetraMaiuscula_Falha()
        {
            // Arrange
            var valor = "senha123@";

            // Act
            var senha = new Senha(valor);
            Action act = () => senha.Validar();

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Senha - Necessário ao menos 1 letra maiúscula", exception.Message);
        }

        [Fact(DisplayName = "ValidarCaractereRepetido - Validar Caractere Repetido - Falha")]
        [Trait("Domain", null)]
        public void Validar_ValidarCaractereRepetido_Falha()
        {
            // Arrange
            var valor = "Senha123@@";

            // Act
            var senha = new Senha(valor);
            Action act = () => senha.Validar();

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Senha - Necessário não possuir caracteres repetidos dentro do conjunto", exception.Message);
        }
    }
}
