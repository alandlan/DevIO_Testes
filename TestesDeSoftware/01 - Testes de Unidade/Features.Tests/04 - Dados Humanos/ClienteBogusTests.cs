using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteBogusTests
    {
        private readonly ClienteTestsBogusFixture _clienteBogusFixture;

        public ClienteBogusTests(ClienteTestsBogusFixture clienteBogusFixture)
        {
            _clienteBogusFixture = clienteBogusFixture;
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Bogus Testes")]
        public void Cliente_Bogus_DeveEstarValido()
        {
            // Arrange
            var cliente = _clienteBogusFixture.GerarClienteValido();

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.True(result);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);

        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Bogus Testes")]
        public void Cliente_Bogus_DeveEstarInválido()
        {
            // Arrange
            var cliente = _clienteBogusFixture.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);

        }
    }
}
