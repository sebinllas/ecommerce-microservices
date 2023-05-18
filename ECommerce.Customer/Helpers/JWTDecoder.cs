using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace ECommerce.Customer.Helpers;

public record JwtHeader(string Alg, string Typ, string Kid);

public record JwtPayload(string UserEmail, string RequestIp, string Iss, string Sub, List<string> Aud, long Iat,
    long Exp, string Azp, string Scope);

public record JwtToken(JwtHeader Header, JwtPayload Payload);

public static class JWTDecoder
{
    
    public static JwtToken Decode(string jwtString)
    {
        var token = jwtString.ToString().Split(" ")[1];
        var jwtHandler = new JwtSecurityTokenHandler();
        var decodedToken = jwtHandler.ReadJwtToken(token).ToString();

        int payloadIndex = decodedToken.IndexOf('.') + 1;
        string headerString = decodedToken.Substring(0, payloadIndex - 1);
        string payloadString = decodedToken.Substring(payloadIndex);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        JwtHeader header = JsonSerializer.Deserialize<JwtHeader>(headerString, options);
        JwtPayload payload = JsonSerializer.Deserialize<JwtPayload>(payloadString, options);
        return new JwtToken(header, payload);
    }
}