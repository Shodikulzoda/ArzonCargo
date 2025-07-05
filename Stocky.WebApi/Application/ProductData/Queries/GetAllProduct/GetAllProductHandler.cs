using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Queries.GetAllProduct;

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