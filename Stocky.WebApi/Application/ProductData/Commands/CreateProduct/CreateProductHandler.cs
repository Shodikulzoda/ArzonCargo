using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Commands.CreateProduct;

public record CreateProductCommand : IRequest<Product>
{
    public string? BarCode { get; set; }
}

public class CreateProductHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            throw new Exception();
        }

        var product = new Product
        {
            BarCode = request.BarCode
        };
        var barcode = productRepository.Queryable.FirstOrDefault(x => x.BarCode == request.BarCode);

        if (barcode != null)
        {
            throw new Exception("Product with this barcode already exists.");
        }

        await productRepository.Add(product);

        return product;
    }
}