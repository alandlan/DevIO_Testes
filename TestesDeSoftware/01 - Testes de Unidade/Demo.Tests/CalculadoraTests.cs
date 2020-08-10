using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            // Arrange
            var calculador = new Calculadora();

            // Act
            var resultado = calculador.Somar(2, 2);

            // Assert
            Assert.Equal(4, resultado);
        }
    }
}
