using Domain.Models;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<User> Add(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User> Update(User user);
    Task<User> Delete(User user);

    Task<User?> GetById(int id);
}