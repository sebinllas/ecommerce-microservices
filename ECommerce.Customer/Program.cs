using ECommerce.Customer;
using ECommerce.Customer.Controllers;
using ECommerce.Customer.Exceptions.Handlers;
using ECommerce.Customer.Helpers;
using ECommerce.Customer.Models;
using ECommerce.Customer.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddDbContext<CustomerDbContext>();
services.AddTransient<CustomerExceptionsHandler>();
services.AddScoped<AuthTokenAccessor>();
services.AddScoped<UserDataAccessor>();
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<IAuditLogger, BasicAuditLogger>();
services.AddScoped<CustomerService>();
services.AddScoped<CustomerController>();
services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSettings"));
services.AddSingleton<MongoDbService>();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomerExceptionsHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();