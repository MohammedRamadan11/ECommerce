using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using ECommerce.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presistence.Repositories
{
    class GenericRepository<TEntity, Tkey>: IGenericRepository<TEntity, Tkey> where TEntity:BaseEntity<Tkey>
    {
        private readonly StoreDbcontext context;

        public GenericRepository(StoreDbcontext context )
        {
            this.context = context;
        }
        public async Task Add(TEntity entity)
        {
           await context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>?> GetAll() => await context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<TEntity>?> GetAll(ISpecifications<TEntity, Tkey> specifications)
        {
           var Query =  SpecificationEvaluator.CreateQuery<TEntity, Tkey>(context.Set<TEntity>(), specifications);
            return await Query.ToListAsync();
        }

        public async Task<TEntity?> GetById(Tkey id) => await context.Set<TEntity>().FindAsync(id);


        public void Update(TEntity entity) => context.Set<TEntity>().Update(entity);
       
    }
}
