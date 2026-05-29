using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.ProductModule
{
   public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public decimal Price { get; set; }
        #region Relations
        #region Brand Relation
        public ProductBrand ProductBrand { get; set; } = default!;
        public int ProductBrandId { get; set; }
        #endregion

        #region type Relation
        public ProductType ProductType { get; set; } = default!;
        public int ProductTypeId { get; set; }
        #endregion

        #endregion
    }
}
