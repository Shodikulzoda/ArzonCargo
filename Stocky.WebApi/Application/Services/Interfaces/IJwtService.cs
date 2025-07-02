namespace Stocky.WebApi.Application.Services.Interfaces;

public interface IJwtService
{
    public string GenerateToken(ReferenceClass.Models.AuthenticationData authenticationData);
}