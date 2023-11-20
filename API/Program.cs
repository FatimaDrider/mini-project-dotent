using API.Extensions;
using Application.Core;
using Application.Shared;
using Domain;
using Domain.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureApplicationServices();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.ConfigurPersisitenceServices(builder.Configuration);
builder.Services.ConfigureDomainServices();


builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scop = app.Services.CreateScope();
var service = scop.ServiceProvider;
try
{
    var context = service.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = service.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}
app.Run();
