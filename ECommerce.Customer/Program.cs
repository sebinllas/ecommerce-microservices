using ECommerce.Customer;
using ECommerce.Customer.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Create an instance of the service collection
var services = builder.Services;

// Register the ICustomerRepository interface and its implementation
services.AddScoped<ICustomerRepository, CustomerRepository>();

// Register the CustomerController class
services.AddScoped<CustomerController>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
