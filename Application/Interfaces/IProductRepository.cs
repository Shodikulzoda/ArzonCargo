using Domain.Models;

namespace Application.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    Product Add(Product product);
    Product Update(Product product);
    bool Delete(int id);
}