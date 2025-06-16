using Domain.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(Guid id);
    Product Create(Product product);
    Product Update(Product product);
    bool Delete(Guid id);
}