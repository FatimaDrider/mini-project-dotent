using AutoMapper;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class ApplicationPersistenceService
    {

        public static void ConfigurPersisitenceServices(this IServiceCollection services, IConfiguration config)
        {
            
             services.AddScoped<IProductRepository, ProductRepository>();
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            
         

            
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICatergoryRepository, CategoryRepository>();

          
        }

    }
}