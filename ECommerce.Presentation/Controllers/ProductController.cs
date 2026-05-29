using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Services.Abstraction;
using ECommerce.Shared.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;



namespace ECommerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await productServices.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await productServices.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAllBrands()
        {
            var Brands = await productServices.GetAllBrandsAsync();
            return Ok(Brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDTO>>> GetAllTypes()
        {
            var Types = await productServices.GetAllTypsAsync();
            return Ok(Types);
        }
    }
}
