
using System.Reflection;
using Application.Core;
using Application.Core.DTOs.EntitiesDto.Category;
using Application.Core.Features.Catergories.Handlers.Command;
using Application.Core.Features.Catergories.Handlers.Query;
using Application.Core.Features.Catergories.Request.Query;
using Application.Core.MappingProfiles;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options =>
          options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

           
            

           // services.AddScoped<IMediator, Mediator>();
           
            

            return services;
        }
    }
}