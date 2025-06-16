using WebApi.Models;

namespace WebApi.Repository.Interfaces;

public interface IUserRepository
{
    Task<User> Add(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User> Update(User user);
    Task<User> Delete(User user);

    Task<User?> GetById(Guid id);
}