using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Stocky.WebApi.Application.Services.Interfaces;

namespace Stocky.WebApi.Application.Services;

public class JwtService(IConfiguration configuration) : IJwtService
{
    public string GenerateToken(Shared.Models.AuthenticationData authenticationData)
    {
        if (authenticationData.UserName == null)
        {
            throw new Exception("null email!");
        }

        var claims = new List<Claim>
        {
            new Claim("id", authenticationData.Id.ToString()),
            new Claim("name", authenticationData.UserName),
            new Claim(ClaimTypes.Role, authenticationData.Role.ToString()),
            new Claim("date", authenticationData.CreatedAt.ToString(CultureInfo.CurrentCulture))
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ??
                                                                  throw new InvalidOperationException("" +
                                                                      "the problem is with key")));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}