using BancoX.Model;
using BancoX.Model.Core;
using System;
using Xunit;

namespace BancoX.Tests
{
    public class ClienteTests
    {
        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = new Cliente(Guid.NewGuid(), "Alan", "Vieira Martins", "12345678901","CPF", DateTime.Now.AddYears(-19), "a@a.com.br");

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = new Cliente(Guid.NewGuid(), "Alan", "Vieira Martins", "12345678901", "CPF", DateTime.Now.AddYears(-18), "aa.com");

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);

        }
    }
}
