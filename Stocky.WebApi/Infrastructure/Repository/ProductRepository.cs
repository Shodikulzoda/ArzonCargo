using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.Shared.Models.Enums;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Databases;

namespace Stocky.WebApi.Infrastructure.Repository;

public class ProductRepository(ApplicationContext context) : BaseRepository<Product>(context), IProductRepository
{
    private readonly ApplicationContext _context1 = context;

    public async Task<Product> Add(Product product)
    {
        await _context1.Products.AddAsync(product);
        await _context1.SaveChangesAsync();

        return product;
    }

    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await _context1.Products.ToListAsync();
    }

    public async Task<Product> Update(Product product)
    {
        _context1.Products.Update(product);
        await _context1.SaveChangesAsync();

        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var product = await _context1.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product is null)
        {
            return false;
        }

        _context1.Products.Remove(product);
        await _context1.SaveChangesAsync();

        return true;
    }

    public async Task<Product?> GetById(int id)
    {
        return await _context1.Products.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Product?> GetByBarCode(string? barCode)
    {
        return await _context1.Products.FirstOrDefaultAsync(o => o.BarCode == barCode);
    }

    public async Task<int> Count()
    {
        return await _context1.Products.CountAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await _context1.Products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .OrderBy(x => x.Status == Status.Created)
            .ToListAsync(cancellationToken);
    }
}