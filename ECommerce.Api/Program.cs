
using ECommerce.Api.Extentions;
using ECommerce.Domain.Contracts;
using ECommerce.Presistence.Data.DataSeed;
using ECommerce.Presistence.Data.DbContexts;
using ECommerce.Presistence.Repositories;
using ECommerce.Services;
using ECommerce.Services.Abstraction;
using ECommerce.Services.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ECommerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region DI
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UntiOfWork>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddAutoMapper(typeof(ClassForAssembly).Assembly);
            builder.Services.AddScoped<IDataIntializer, DataIntializer>();
            builder.Services.AddTransient<ProductPictureResolver>();
            #endregion

            var app = builder.Build();
           await app.MigrateDataBase();
            await app.SeedingData();

            #region piplines
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
