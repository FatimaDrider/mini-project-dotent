using AutoMapper;
using Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class ApplicationnServiceRegistration
    {

        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            
      //     services.AddAutoMapper(typeof(Categ).Assembly);
        //    services.AddAutoMapper(typeof(ProductMappingProfiles).Assembly);
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
          
        }

    }
}