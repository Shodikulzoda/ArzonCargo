using Domain.Models;

namespace Application.Interfaces;

public interface IPocketItemRepository
{
    IEnumerable<PocketItem> GetAll();
    PocketItem GetById(int id);
    PocketItem Add(PocketItem pocket);
    PocketItem Update(PocketItem pocket);
    bool Delete(int id);

}