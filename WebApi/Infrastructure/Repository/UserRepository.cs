using Microsoft.EntityFrameworkCore;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

public class UserRepository(ApplicationContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User> Add(User user)
    {
        await context.Users.AddAsync(user);
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

    public async Task<User?> GetById(int id)
    {
        var firstOrDefault = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        return firstOrDefault;
    }

    public async Task<int> Count()
    {
        return await context.Users.CountAsync();
    }

    public async Task<IEnumerable<User>> GetUserByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await context.Users
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}