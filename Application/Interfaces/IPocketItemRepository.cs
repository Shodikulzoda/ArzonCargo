using Domain.Models;

namespace Application.Interfaces;

public interface IPocketItemRepository
{
    Task<PocketItem> Add(PocketItem pocketItem);
    Task<IEnumerable<PocketItem>> GetAll();
    Task<PocketItem> Update(PocketItem pocketItem);
    Task<PocketItem> Delete(PocketItem pocketItem);
    
    Task<PocketItem?> GetById(int id);

}