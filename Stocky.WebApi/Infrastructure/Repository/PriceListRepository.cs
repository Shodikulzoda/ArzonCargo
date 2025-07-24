using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Databases;

namespace Stocky.WebApi.Infrastructure.Repository;

public class PriceListRepository(ApplicationContext context) : BaseRepository<PriceList>(context), IPriceListRepository
{
    public async Task<bool> AddAsync(PriceList priceList)
    {
        await context.PriceLists.AddAsync(priceList);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<PriceList>> GetAllAsync()
    {
        return await context.PriceLists.AsNoTracking().ToListAsync();
    }

    public async Task<PriceList?> GetPriceAsync()
    {
        var price = await context.PriceLists
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .LastOrDefaultAsync();
        return price ?? throw new KeyNotFoundException("Price not found.");
    }
}