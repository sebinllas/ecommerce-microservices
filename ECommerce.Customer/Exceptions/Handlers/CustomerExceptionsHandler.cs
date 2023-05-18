using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Customer.Exceptions.Handlers;

public class CustomerExceptionsHandler : IMiddleware
{

    public CustomerExceptionsHandler()
    {
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomerNotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = "Item not Found",
                Title = "Item not Found",
                Detail = ex.Message,

            };
            var json = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}