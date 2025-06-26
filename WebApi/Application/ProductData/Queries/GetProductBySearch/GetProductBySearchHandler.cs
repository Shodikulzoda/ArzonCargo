using MediatR;
using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.ProductData.Queries.GetProductBySearch;

public record GetProductBySearchQuery : IRequest<List<Product>>
{
    public string? Text { get; set; }
}

public class GetProductBySearchHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductBySearchQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetProductBySearchQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Text))
        {
            return new List<Product>();
        }

        var lower = request.Text.ToLower();
        var products = await productRepository.Queryable
            .Where(x => x.Id.ToString().Contains(lower)
                        || x.BarCode.ToLower().Contains(lower) ||
                        x.Status.ToString().Contains(lower)).ToListAsync();

        return products;
    }
}