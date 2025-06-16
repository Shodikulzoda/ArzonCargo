using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class PocketRepository(ApplicationContext context) : IPocketItemRepository
{
    public IEnumerable<PocketItem> GetAll()
    {
        return context.PocketItem.ToList();
    }

    public PocketItem GetById(Guid id)
    {
        var pocketItem = context.PocketItem.FirstOrDefault(o => o.Id == id);
        if (pocketItem == null)
            throw new Exception("PocketItem not found");
        return pocketItem;
    }

    public PocketItem Create(PocketItem pocket)
    {
        var entity = context.PocketItem.Add(pocket).Entity;
        context.SaveChanges();
        return entity;
    }

    public PocketItem Update(PocketItem pocket)
    {
        var existing = GetById(pocket.Id);
        if (existing == null)
            throw new Exception("PocketItem not found");
        context.PocketItem.Update(pocket);
        context.SaveChanges();
        return pocket;
    }

    public bool Delete(Guid id)
    {
        var pocketItem = GetById(id);
        if (pocketItem == null)
            throw new Exception("PocketItem not found");
        context.PocketItem.Remove(pocketItem);
        context.SaveChanges();
        return true;
    }
}