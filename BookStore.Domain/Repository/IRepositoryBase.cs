using BookStore.Shared.EntityBase;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetNoTracking(Guid id);
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
    }
}
