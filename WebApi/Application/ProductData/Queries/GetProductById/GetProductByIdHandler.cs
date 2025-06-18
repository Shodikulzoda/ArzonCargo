using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Application.ProductData.Queries.GetProductById;
using WebApi.Domain.Models;

namespace WebApi.Application.ProductData.Queries.GetProductById;

public record GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}

public class GetProductByIdHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        
        return product;
    }
}