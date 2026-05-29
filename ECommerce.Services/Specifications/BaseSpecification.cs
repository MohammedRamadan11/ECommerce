using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications
{
    abstract class BaseSpecification<TEntity, Tkey> : ISpecifications<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludesExpressions => [];
        protected void AddInclude(Expression<Func<TEntity,object>> IncludeExp)
        {
            IncludesExpressions.Add(IncludeExp);
        }
    }
}
