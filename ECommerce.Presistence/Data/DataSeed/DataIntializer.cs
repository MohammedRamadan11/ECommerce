using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Presistence.Data.DataSeed
{
   public  class DataIntializer : IDataIntializer
    {
        private readonly StoreDbcontext context;

        public DataIntializer(StoreDbcontext context)
        {
            this.context = context;
        }
        public async Task Intialze()
        {
            try
            {
                   var productExist = await context.Products.AnyAsync();
                var productBrandExist = await context.ProductBrands.AnyAsync();
                var productTypeExist = await context.ProductTypes.AnyAsync();
                if (productExist && productTypeExist && productBrandExist) return;
                if (!productBrandExist)
                {
                    await DataSeed<ProductBrand, int>("brands.json", context.ProductBrands);
                }
                if (!productTypeExist)
                { await DataSeed<ProductType, int>("types.json", context.ProductTypes); }
                await context.SaveChangesAsync();
                if (!productExist)
                {
                    await DataSeed<Product, int>("products.json", context.Products);
                   await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"error while seeding data : {ex}"); ;
            }
        }
        private async Task DataSeed<T, Tkey>(string FileName, DbSet<T> dbset) where T : BaseEntity<Tkey>
        {

            string filepath = @"..\ECommerce.Presistence\Data\DataSeed\JsonData\" + FileName;
            if (!File.Exists(filepath))
                throw new FileNotFoundException("file not found ", filepath);
            try
            {
                var datastreem = File.OpenRead(filepath);
                var data = await JsonSerializer.DeserializeAsync<List<T>>(datastreem, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (data is not null)
                   await context.AddRangeAsync(data);
            }
            catch (Exception)
            {

                Console.WriteLine("error while seeding the data ");
            }


        }

    }
}
