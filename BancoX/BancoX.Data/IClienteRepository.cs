using BancoX.Model;
using System;

namespace BancoX.Data
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorEmail(string email);
    }
}
