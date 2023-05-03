using Microsoft.EntityFrameworkCore;
using ProductManagement.BLL.DTOs;
using ProductManagement.BLL.Services;
using ProductManagement.DAL.Data;
using AutoMapper;
using ProductManagement.DAL.Interfaces;
using ProductManagement.DAL.Repositories;
using ProductManagement.BLL.Interfaces;
using ProductManagement.WebApi.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ProductManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagementConnectionString")));
// Repository configurations
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
// Service configurations
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
// Mapper configuration
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(ProductProfile)));
//RabbitMQ configuration
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
