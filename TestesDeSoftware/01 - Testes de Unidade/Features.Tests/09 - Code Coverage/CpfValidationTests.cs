using Features.Core;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Features.Tests { 
    public class CpfValidationTests
    {
        [Theory(DisplayName = "CPF Validos")]
        [Trait("Categorias","CPF Validation Tests")]
        [InlineData("15231766607")]
        [InlineData("78246847333")]
        [InlineData("64184957307")]
        [InlineData("21681764423")]
        [InlineData("13830803800")]
        public void Cpf_ValidarMultiplosNumeros_TodosDevemSerValidados(string cpf)
        {
            //Assert
            var cpfValidation = new CpfValidation();

            //Act & Assert
            cpfValidation.EhValido(cpf).Should().BeTrue();
        }

        [Theory(DisplayName = "CPF Invalidos")]
        [Trait("Categorias", "CPF Validation Tests")]
        [InlineData("1231323123123123")]
        [InlineData("233234232332")]
        [InlineData("12312312333")]
        [InlineData("12331231se2")]
        [InlineData("123123123")]
        public void Cpf_ValidarMultiplosNumeros_TodosDevemSerInvalidados(string cpf)
        {
            //Assert
            var cpfValidation = new CpfValidation();

            //Act & Assert
            cpfValidation.EhValido(cpf).Should().BeFalse();
        }
    }
}

