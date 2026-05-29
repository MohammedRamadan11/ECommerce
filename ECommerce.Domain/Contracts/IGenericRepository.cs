using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Contracts
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity :BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>?> GetAll();
        Task<IEnumerable<TEntity>?> GetAll(ISpecifications<TEntity,Tkey> specifications);
        Task<TEntity?> GetById(Tkey id);
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

    }
}
