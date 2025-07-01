namespace Stocky.WebApi.Application.Interfaces;

public interface IAuthRepository : IBaseRepository<ReferenceClass.Models.AuthenticationData>
{
    Task<ReferenceClass.Models.AuthenticationData> Add(ReferenceClass.Models.AuthenticationData auth);
    Task<IEnumerable<ReferenceClass.Models.AuthenticationData>> GetAll();
}