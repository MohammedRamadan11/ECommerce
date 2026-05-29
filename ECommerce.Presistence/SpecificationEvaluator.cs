using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presistence
{
   static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity,Tkey>(IQueryable<TEntity> EntryPoint, ISpecifications<TEntity,Tkey> specifications) where TEntity : BaseEntity<Tkey>
        {
            var Query = EntryPoint;
            if (specifications is not null)
            {
                if (specifications.IncludesExpressions is not null && specifications.IncludesExpressions.Any())
                {
                    Query = specifications.IncludesExpressions.Aggregate(Query, (CurrentQuery, includeExp) => CurrentQuery.Include(includeExp));
                }
            }
            return Query;
        }
    }
}
