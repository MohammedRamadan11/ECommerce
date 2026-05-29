using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using ECommerce.Presistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presistence.Repositories
{
   public class UntiOfWork : IUnitOfWork
    {
        private readonly StoreDbcontext context;
        private Dictionary<Type,object> repos = [];

        public UntiOfWork(StoreDbcontext context)
        {
            this.context = context;
        }
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var entityType = typeof(TEntity);

            if (repos.TryGetValue(entityType, out var repository))
                return (IGenericRepository<TEntity, Tkey>)repository;

           
            var newRepo = new GenericRepository<TEntity,Tkey>(context);

            repos[entityType] = newRepo;

            return newRepo;
        }

        public async Task<int> SaveChanges()
        {
          return  await context.SaveChangesAsync();
        }
    }
}
