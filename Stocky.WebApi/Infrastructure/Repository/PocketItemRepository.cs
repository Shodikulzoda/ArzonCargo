using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Databases;

namespace Stocky.WebApi.Infrastructure.Repository;

public class PocketItemRepository(ApplicationContext context)
    : BaseRepository<PocketItem>(context), IPocketItemRepository
{
    private readonly ApplicationContext _context1 = context;

    public async Task<IEnumerable<PocketItem>> GetAll()
    {
        return await _context1.PocketItem.ToListAsync();
    }

    public async Task<PocketItem?> GetById(int id)
    {
        var pocketItem = await _context1.PocketItem.FirstOrDefaultAsync(o => o.Id == id);
        if (pocketItem is null)
        {
            return null;
        }

        return pocketItem;
    }

    public async Task<PocketItem> Add(PocketItem pocketItem)
    {
        var findPocketItem = await _context1.PocketItem.SingleOrDefaultAsync(x => x.ProductId == pocketItem.ProductId);
        if (findPocketItem is not null)
        {
            return pocketItem;
        }

        await _context1.PocketItem.AddAsync(pocketItem);
        await _context1.SaveChangesAsync();

        return pocketItem;
    }

    public async Task<PocketItem> Update(PocketItem pocketItem)
    {
        _context1.PocketItem.Update(pocketItem);
        await _context1.SaveChangesAsync();

        return pocketItem;
    }

    public async Task<bool> Delete(int id)
    {
        var pocketItem = await _context1.PocketItem.FirstOrDefaultAsync(x => x.Id == id);
        if (pocketItem is null)
        {
            return false;
        }

        _context1.PocketItem.Remove(pocketItem);
        await _context1.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<PocketItem?>> GetByPocketId(int id)
    {
        var pockets = await _context1.PocketItem.Where(x => x.PocketId == id).ToListAsync();

        if (pockets is null)
        {
            return null;
        }

        return pockets;
    }

    public async Task<int> Count()
    {
        return await _context1.PocketItem.CountAsync();
    }

    public async Task<IEnumerable<PocketItem>> GetPocketItemByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await _context1.PocketItem
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<PocketItem?> GetByProductIdAndPocketId(int productId, int pocketId)
    {
        var firstOrDefaultAsync =
            await _context1.PocketItem.FirstOrDefaultAsync(x => x.ProductId == productId &&
                                                                x.PocketId == pocketId);

        if (firstOrDefaultAsync is null)
        {
            return null;
        }

        return firstOrDefaultAsync;
    }
}