using BancoX.Model;
using System;
using System.Collections.Generic;

namespace BancoX.Service
{
    public interface IClienteService : IDisposable
    {
        IEnumerable<Cliente> ObterTodosAtivos();
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorEmail(string email);
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Inativar(Cliente cliente);
    }
}