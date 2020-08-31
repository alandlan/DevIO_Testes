using BancoX.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BancoX.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);

        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> ObterTodos();

        void Atualizar(TEntity obj);

        void Inativar(TEntity obj);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        int Commit();
    }
}
