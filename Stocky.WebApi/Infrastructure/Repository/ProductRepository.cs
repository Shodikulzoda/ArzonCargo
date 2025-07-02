using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using ReferenceClass.Models.Enums;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Databases;

namespace Stocky.WebApi.Infrastructure.Repository;

public class ProductRepository(ApplicationContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<Product> Add(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return product;
    }

    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product> Update(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();

        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        if (product is null)
        {
            return false;
        }
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<Product?> GetById(int id)
    {
        return await context.Products.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<int> Count()
    {
        return await context.Products.CountAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await context.Products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .OrderBy(x => x.Status == Status.Created)
            .ToListAsync(cancellationToken);
    }
}