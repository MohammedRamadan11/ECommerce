using AutoMapper;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Shared.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.AutoMapper
{

    class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductBrand, BrandDTO>();
            CreateMap<ProductType, TypeDTO>();
            CreateMap<Product, ProductDTO>()
                .ForMember(dt => dt.ProductBrand, opt => opt.MapFrom(p => p.ProductBrand.Name))
                .ForMember(dt => dt.ProductType, opt => opt.MapFrom(p => p.ProductType.Name))
                .ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom<ProductPictureResolver>())
                ;

        }
    }
}
