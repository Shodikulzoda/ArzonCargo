using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Queries.GetByBarCode;

public class GetByBarCodeQuery : IRequest<Product>
{
    public string BarCode  { get; set; }
}

public class GetProductByBarCodeHandler(IProductRepository productRepository)
    : IRequestHandler<GetByBarCodeQuery, Product>
{
    public async Task<Product> Handle(GetByBarCodeQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.Queryable.FirstOrDefaultAsync(x=> x.BarCode == request.BarCode, cancellationToken: cancellationToken);
        
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        
        return product;
    }
}