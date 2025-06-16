using Domain.Models;

namespace Application.Interfaces;

public interface IProductRepository
{
    Task<Product> Add(Product product);
    Task<IEnumerable<Product?>> GetAll();
    Task<Product> Update(Product product);
    Task<Product> Delete(Product product);

    Task<Product?> GetById(int id);
}