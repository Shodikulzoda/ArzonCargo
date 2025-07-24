using Stocky.Shared.Models;

namespace Stocky.WebApi.Application.Interfaces;

public interface IPriceListRepository : IBaseRepository<PriceList>
{
    Task<bool> AddAsync(PriceList priceList);
    Task<IEnumerable<PriceList>> GetAllAsync();
    Task<PriceList?> GetPriceAsync();
}