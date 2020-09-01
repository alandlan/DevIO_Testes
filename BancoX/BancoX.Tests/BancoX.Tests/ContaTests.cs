using BancoX.Model.DadosBancarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BancoX.Tests
{
    public class ContaTests
    {
        [Fact(DisplayName = "Nova Conta Válida")]
        [Trait("Categoria", "Conta Tests")]
        public void Conta_NovaConta_DeveEstarValida()
        {
            // Arrange
            var conta = new Conta(1234, 1, TipoConta.CORRENTE);
            conta.IncluirNumeroConta(1);

            // Act
            var result = conta.EhValido();

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Nova Conta Inálida")]
        [Trait("Categoria", "Conta Tests")]
        public void Conta_NovaConta_DeveEstarinvalida()
        {
            // Arrange
            var conta = new Conta(1234, 1, TipoConta.POUPANCA);

            // Act
            var result = conta.EhValido();

            // Assert
            Assert.False(result);

        }
    }
}
