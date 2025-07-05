using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Databases;

namespace Stocky.WebApi.Infrastructure.Repository;

public class AuthRepository(ApplicationContext context) : BaseRepository<AuthenticationData>(context), IAuthRepository
{
    private readonly ApplicationContext _context1 = context;

    public async Task<AuthenticationData> Add(AuthenticationData auth)
    {
        _context1.AuthenticationData.Add(auth);
        await _context1.SaveChangesAsync();
        return auth;
    }

    public async Task<IEnumerable<AuthenticationData>> GetAll()
    {
        return await _context1.AuthenticationData.ToListAsync();
    }
}