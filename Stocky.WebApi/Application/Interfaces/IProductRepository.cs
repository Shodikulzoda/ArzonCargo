using Stocky.Shared.Models;

namespace Stocky.WebApi.Application.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> Add(Product product);
    Task<IEnumerable<Product?>> GetAll();
    Task<Product> Update(Product product);
    Task<bool> Delete(int id);

    Task<Product?> GetById(int id);
    Task<int> Count();
    Task<IEnumerable<Product>> GetProductByPagination(int page, int pageSize, CancellationToken cancellationToken);
}