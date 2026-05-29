using AutoMapper;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Services.Abstraction;
using ECommerce.Services.Specifications.ProductSpecification;
using ECommerce.Shared.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
 public   class ProductServices : IProductServices
    {
        private readonly IUnitOfWork repos;
        private readonly IMapper mapper;

        public ProductServices(IUnitOfWork Repos , IMapper Mapper)
        {
            repos = Repos;
            mapper = Mapper;
        }

        public async Task<IEnumerable<BrandDTO>?> GetAllBrandsAsync()
        {
            var brands =await repos.GetRepository<ProductBrand, int>().GetAll();
            if (brands == null)
                return [];
            
                var mappedbrands = mapper.Map < IEnumerable<ProductBrand>,IEnumerable <BrandDTO>> (brands);
            return mappedbrands;
        }

        public async Task<IEnumerable<ProductDTO>?> GetAllProductsAsync()
        {
            var specific = new ProductWithBrandandTypeSpecification();
            var products = await repos.GetRepository<Product, int>().GetAll(specific);
            if (products == null) return [];
            var mappedProduct = mapper.Map<IEnumerable<ProductDTO>>(products);
            return mappedProduct;
        }

        public async Task<IEnumerable<TypeDTO>?> GetAllTypsAsync()
        {
            var types = await repos.GetRepository<ProductBrand, int>().GetAll();
            if (types == null) return [];
            var mappedTypes = mapper.Map<IEnumerable<TypeDTO>>(types);
            return mappedTypes;

        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await repos.GetRepository<Product, int>().GetById(id);
            if (product == null) return null;
            var mappedproduct = mapper.Map<ProductDTO>(product);
            return mappedproduct;

        }
    }
}
