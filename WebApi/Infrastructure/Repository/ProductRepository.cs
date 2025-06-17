using Microsoft.EntityFrameworkCore;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

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

    public async Task<Product> Delete(Product product)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> GetById(int id)
    {
        return await context.Products.FirstOrDefaultAsync(o => o.Id == id);
    }
}