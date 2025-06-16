using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class ProductRepository(ApplicationContext context) : IProductRepository
{
    public IEnumerable<Product> GetAll()
    {
        return context.Products.ToList();
    }

    public Product GetById(Guid id)
    {
        var product = context.Products.FirstOrDefault(o => o.Id == id);
        if (product == null)
            throw new Exception("Product not found");
        return product;
    }

    public Product Create(Product product)
    {
        var entity = context.Products.Add(product).Entity;
        context.SaveChanges();
        return entity;
    }

    public Product Update(Product product)
    {
        var existing = GetById(product.Id);
        if (existing == null)
            throw new Exception("Product not found");
        context.Products.Update(product);
        context.SaveChanges();
        return product;
    }

    public bool Delete(Guid id)
    {
        var product = GetById(id);
        if (product == null)
            throw new Exception("Product not found");
        context.Products.Remove(product);
        context.SaveChanges();
        return true;
    }
}