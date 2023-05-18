using Microsoft.Net.Http.Headers;

namespace ECommerce.Customer.Helpers;

public class AuthTokenAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AuthTokenAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string GetToken()
    {
        return _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];
    }
}