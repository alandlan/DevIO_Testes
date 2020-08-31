using BancoX.Data;
using BancoX.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoX.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClienteService(IClienteRepository clienteRepository, IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        public void Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Adicionar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Olá", "Bem vindo!"));
        }

        public void Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Atualizar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Mudanças", "Dê uma olhada!"));
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public void Inativar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            cliente.Inativar();

            _clienteRepository.Inativar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Adeus", "Até logo!"));
        }

        public IEnumerable<Cliente> ObterTodosAtivos()
        {
            return _clienteRepository.ObterTodos().Where(c=>c.Ativo);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }
    }
}
