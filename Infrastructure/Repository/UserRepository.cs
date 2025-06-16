using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

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