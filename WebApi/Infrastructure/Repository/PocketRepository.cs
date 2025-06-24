using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

public class PocketRepository(ApplicationContext context) : BaseRepository<Pocket>(context), IPocketRepository
{
    public async Task<Pocket> Add(Pocket pocket)
    {
        var entity = context.Pockets.Add(pocket).Entity;
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Pocket>> GetAll()
    {
        return await context.Pockets.ToListAsync();
    }

    public async Task<Pocket> Update(Pocket pocket)
    {
        context.Pockets.Update(pocket);
        await context.SaveChangesAsync();
        return pocket;
    }

    public async Task<Pocket> Delete(Pocket pocket)
    {
        context.Pockets.Remove(pocket);
        await context.SaveChangesAsync();
        return pocket;
    }

    public async Task<Pocket?> GetById(int id)
    {
        return await context.Pockets.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<int> Count()
    {
        return await context.Pockets.CountAsync();
    }

    public async Task<IEnumerable<Pocket>> GetOrderByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await context.Pockets
            .Skip((page) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}