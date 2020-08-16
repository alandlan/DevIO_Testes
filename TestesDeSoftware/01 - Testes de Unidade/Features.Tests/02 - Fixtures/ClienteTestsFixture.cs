﻿using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture> { }
    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Alan",
                "Martins",
                DateTime.Now.AddYears(-30),
                "alan@alan.com",
                true,
                DateTime.Now
                );

            return cliente;
        }

        public Cliente GerarClienteInvalido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "alan2alan.com",
                true,
                DateTime.Now
                );

            return cliente;
        }
        public void Dispose()
        {
        }
    }
}