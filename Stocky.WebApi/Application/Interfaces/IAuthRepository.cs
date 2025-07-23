namespace Stocky.WebApi.Application.Interfaces;

public interface IAuthRepository : IBaseRepository<Shared.Models.AuthenticationData>
{
    Task<Shared.Models.AuthenticationData> Add(Shared.Models.AuthenticationData auth);
    Task<IEnumerable<Shared.Models.AuthenticationData>> GetAll();
    Task<string> GetUserNameById(int id);
}