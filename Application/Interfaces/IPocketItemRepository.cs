using Domain.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IPocketItemRepository
{
    IEnumerable<PocketItem> GetAll();
    PocketItem GetById(Guid id);
    PocketItem Create(PocketItem pocket);
    PocketItem Update(PocketItem pocket);
    bool Delete(Guid id);

}