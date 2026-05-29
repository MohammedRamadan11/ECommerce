using ECommerce.Domain.Contracts;
using ECommerce.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Api.Extentions
{
    public static class WebApplicationRegister
    {
        public async static Task<WebApplication>MigrateDataBase(this WebApplication app)
        {
         await  using  var scope = app.Services.CreateAsyncScope();
            var dbcontext = scope.ServiceProvider.GetRequiredService<StoreDbcontext>();
            var appendingmigraiton =await dbcontext.Database.GetPendingMigrationsAsync();
            if (appendingmigraiton.Any())
            { dbcontext.Database.Migrate(); }
            return app;

        }
        public static async Task<WebApplication> SeedingData(this WebApplication app)
        {
           await using var scope = app.Services.CreateAsyncScope();
            var dataintializer = scope.ServiceProvider.GetRequiredService<IDataIntializer>();
            await dataintializer.Intialze();
            return app;

        }
    }
}
