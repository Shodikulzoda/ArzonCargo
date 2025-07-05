using Stocky.Shared.Models;

namespace Stocky.WebApi.Application.Interfaces;

public interface IUserRepository : IBaseRepository<User> 
{
    Task<User> Add(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User> Update(User user);
    Task<bool> Delete(int id);
    
    Task<User?> GetById(int id);
    Task<int> Count();
    Task<IEnumerable<User>> GetUserByPagination(int page, int pageSize, CancellationToken cancellationToken);
}