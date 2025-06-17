using Microsoft.EntityFrameworkCore;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public IQueryable<T> Querable { get; set; }

    private readonly ApplicationContext _context;

    public BaseRepository(ApplicationContext context)
    {
        Querable = context.Set<T>().AsQueryable();
        _context = context;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            return false;

        _context.Set<T>().Remove(result);
        await _context.SaveChangesAsync();

        return true;
    }
}