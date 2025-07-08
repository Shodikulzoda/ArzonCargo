using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.Shared.Models.Enums;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Queries.GetByBarCode;

public class GetByBarCodeQuery : IRequest<Product>
{
    public string BarCode { get; set; }
}

public class GetProductByBarCodeHandler(IProductRepository productRepository)
    : IRequestHandler<GetByBarCodeQuery, Product>
{
    public async Task<Product> Handle(GetByBarCodeQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.Queryable
            .FirstOrDefaultAsync(x => x.BarCode == request.BarCode, cancellationToken);

        if (product == null)
        {
            return null;
        }

        if (product.Status == Status.Completed)
        {
            throw new Exception("status of the product was completed");
        }

        return product;
    }
}