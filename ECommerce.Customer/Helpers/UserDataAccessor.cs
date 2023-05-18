using ECommerce.Customer.Models;

namespace ECommerce.Customer.Helpers;

public class UserDataAccessor
{
    private readonly AuthTokenAccessor _tokenAccessor;
    
    public UserDataAccessor(AuthTokenAccessor tokenAccessor)
    {
        _tokenAccessor = tokenAccessor;
    }

    private string GetEmailFromToken(string token)
    {
        return JWTDecoder.Decode(token).Payload.UserEmail;
    }

    private string GetRequestIp(string token)
    {
        return JWTDecoder.Decode(token).Payload.RequestIp;
    }

    public UserRequestData GetUserData()
    {
        var token = _tokenAccessor.GetToken();
        var userEmail = GetEmailFromToken(token);
        var requestIp = GetRequestIp(token);
        return new UserRequestData(userEmail, requestIp);
    }
}