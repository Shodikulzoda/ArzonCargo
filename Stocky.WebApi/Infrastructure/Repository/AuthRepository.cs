using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Data;

namespace Stocky.WebApi.Infrastructure.Repository;

public class AuthRepository(ApplicationContext context) : BaseRepository<AuthenticationData>(context), IAuthRepository
{
    public async Task<AuthenticationData> Add(AuthenticationData auth)
    {
        context.AuthenticationData.Add(auth);
        await context.SaveChangesAsync();
        return auth;
    }

    public async Task<IEnumerable<AuthenticationData>> GetAll()
    {
        return await context.AuthenticationData.ToListAsync();
    }
}