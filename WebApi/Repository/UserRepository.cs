using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Data;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository;

public class UserRepository(ApplicationContext context) : IUserRepository
{
    public async Task<User> Add(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }

    public async Task<User> Update(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User> Delete(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetById(Guid id)
    {
        var firstOrDefault = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        return firstOrDefault;
    }
}