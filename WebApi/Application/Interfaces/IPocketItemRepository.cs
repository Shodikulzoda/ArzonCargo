using ReferenceClass.Models;

namespace WebApi.Application.Interfaces;

public interface IPocketItemRepository : IBaseRepository<PocketItem>
{
    Task<PocketItem> Add(PocketItem pocketItem);
    Task<IEnumerable<PocketItem>> GetAll();
    Task<PocketItem> Update(PocketItem pocketItem);
    Task<PocketItem> Delete(PocketItem pocketItem);

    Task<PocketItem?> GetById(int id);
    Task<int> Count();

    Task<IEnumerable<PocketItem>>
        GetPocketItemByPagination(int page, int pageSize, CancellationToken cancellationToken);
}