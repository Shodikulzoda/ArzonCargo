using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductRepository(ApplicationContext context) : IProductRepository
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