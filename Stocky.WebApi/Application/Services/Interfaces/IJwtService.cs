namespace Stocky.WebApi.Application.Services.Interfaces;

public interface IJwtService
{
    public string GenerateToken(Shared.Models.AuthenticationData authenticationData);
}