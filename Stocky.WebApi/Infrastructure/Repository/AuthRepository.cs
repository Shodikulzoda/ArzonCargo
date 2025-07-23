using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Databases;

namespace Stocky.WebApi.Infrastructure.Repository;

public class AuthRepository(ApplicationContext context) : BaseRepository<AuthenticationData>(context), IAuthRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<AuthenticationData> Add(AuthenticationData auth)
    {
        _context.AuthenticationData.Add(auth);
        await _context.SaveChangesAsync();
        return auth;
    }

    public async Task<IEnumerable<AuthenticationData>> GetAll()
    {
        return await _context.AuthenticationData.ToListAsync();
    }

    public async Task<string> GetUserNameById(int id)
    {
        var username = await _context.AuthenticationData
            .Where(a => a.Id == id)
            .Select(a => a.UserName)
            .FirstOrDefaultAsync();

        if (username is null)
        {
            throw new Exception("User not found");
        }

        return username;
    }
}