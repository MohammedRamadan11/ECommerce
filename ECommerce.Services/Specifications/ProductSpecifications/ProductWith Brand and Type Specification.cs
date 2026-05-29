using ECommerce.Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications.ProductSpecification
{
    class ProductWithBrandandTypeSpecification:BaseSpecification<Product,int>
    {
        public ProductWithBrandandTypeSpecification():base()
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }
    }
}
