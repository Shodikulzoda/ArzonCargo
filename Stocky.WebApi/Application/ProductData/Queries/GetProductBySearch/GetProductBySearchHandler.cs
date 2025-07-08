using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Queries.GetProductBySearch;

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
            return [];
        }

        request.Text = request.Text.ToLower();
        var products = await productRepository.Queryable
            .Where(x =>
                EF.Functions.Like(x.BarCode.ToLower(), $"%{request.Text}%") ||
                EF.Functions.Like(x.Status.ToString().ToLower(), $"%{request.Text}%"))
            .ToListAsync(cancellationToken);

        return products;
    }
}