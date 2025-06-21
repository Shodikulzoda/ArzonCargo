using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

public class PocketRepository(ApplicationContext context) : BaseRepository<PocketItem>(context), IPocketItemRepository
{
    public async Task<IEnumerable<PocketItem>> GetAll()
    {
        return await context.PocketItem.ToListAsync();
    }

    public async Task<PocketItem?> GetById(int id)
    {
        var pocketItem = await context.PocketItem.FirstOrDefaultAsync(o => o.Id == id);
        if (pocketItem is null)
        {
            return null;
        }

        return pocketItem;
    }

    public async Task<PocketItem> Add(PocketItem pocketItem)
    {
        await context.PocketItem.AddAsync(pocketItem);
        await context.SaveChangesAsync();

        return pocketItem;
    }

    public async Task<PocketItem> Update(PocketItem pocketItem)
    {
        context.PocketItem.Update(pocketItem);
        await context.SaveChangesAsync();

        return pocketItem;
    }

    public async Task<PocketItem> Delete(PocketItem pocketItem)
    {
        context.PocketItem.Remove(pocketItem);
        await context.SaveChangesAsync();

        return pocketItem;
    }

    public async Task<int> Count()
    {
        return await context.PocketItem.CountAsync();
    }

    public async Task<IEnumerable<PocketItem>> GetPocketItemByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await context.PocketItem
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}