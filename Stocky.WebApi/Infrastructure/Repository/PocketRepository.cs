using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Data;

namespace Stocky.WebApi.Infrastructure.Repository;

public class PocketRepository(ApplicationContext context) : BaseRepository<Pocket>(context), IPocketRepository
{
    private readonly ApplicationContext _context1 = context;

    public async Task<Pocket> Add(Pocket pocket)
    {
        var entity = _context1.Pockets.Add(pocket).Entity;
        await _context1.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Pocket>> GetAll()
    {
        return await _context1.Pockets.ToListAsync();
    }

    public async Task<Pocket> Update(Pocket pocket)
    {
        _context1.Pockets.Update(pocket);
        await _context1.SaveChangesAsync();
        return pocket;
    }

    public async Task<bool> Delete(int id)
    {
        var pocket = await _context1.Pockets.FirstOrDefaultAsync(x => x.Id == id);
        if (pocket is null)
        {
            return false;
        }

        _context1.Pockets.Remove(pocket);
        await _context1.SaveChangesAsync();
        return true;
    }

    public async Task<Pocket?> GetById(int id)
    {
        return await _context1.Pockets.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Pocket> GetByUserId(int id)
    {
        var firstOrDefaultAsync = await _context1.Pockets.Include(x => x.PocketItems)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.UserId == id);
        if (firstOrDefaultAsync is null)
        {
            return null;
        }

        return firstOrDefaultAsync;
    }

    public async Task<int> Count()
    {
        return await _context1.Pockets.CountAsync();
    }

    public async Task<IEnumerable<Pocket>> GetOrderByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await _context1.Pockets
            .Skip((page) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}