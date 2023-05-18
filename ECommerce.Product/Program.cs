using ECommerce.Product;
using ECommerce.Product.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Create an instance of the service collection
var services = builder.Services;

services.AddScoped<ProductDbContext>();

// Register the IProductRepository interface and its implementation
services.AddScoped<IProductRepository, ProductRepository>();

// Register the ProductController class
services.AddScoped<ProductController>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

//app.UseAuthorization();

app.MapControllers();

app.Run();