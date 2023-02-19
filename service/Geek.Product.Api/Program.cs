using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Geek.Product.Api.Helper;
using Geek.Product.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var IsDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

var conn = builder.Configuration.GetConnectionString("DB");
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => 
{
    var assembly = Assembly.GetExecutingAssembly();

    builder.Register(x =>
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProdutoContext>();
        optionsBuilder.UseSqlServer(conn);
        return new ProdutoContext(optionsBuilder.Options);
    }).InstancePerLifetimeScope();

    builder.RegisterType<Geek.Product.Api.Infrastructure.Repository.ProdutoRepository>().As<Geek.Product.Api.Domain.Interface.IProdutoRepository>();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
