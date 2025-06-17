using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.ProductData.Queries.GetAllProduct;

public record GetAllProductQuery : IRequest<IEnumerable<Product>>;

public class GetAllProductHandler(IProductRepository productRepository)
    : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request,
        CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAll();
        
        return products;
    }
}