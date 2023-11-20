
using Application.Core.MappingProfiles;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Shared
{
    public static class ApplicationnServiceRegistration
    {

        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
          //  services.AddAutoMapper(typeof(CategoryMappingProfiles).Assembly);
           // services.AddAutoMapper(typeof(ProductMappingProfiles).Assembly);
            
         //   services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
         services.AddMediatR(typeof(ApplicationnServiceRegistration).Assembly);
            services.AddAutoMapper(typeof(ApplicationnServiceRegistration).Assembly);
        }

    }
}