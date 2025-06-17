using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.ProductData.Commands.CreateProduct;

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

        await productRepository.Add(product);

        return product;
    }
}