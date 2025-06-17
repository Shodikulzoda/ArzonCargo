using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;
using WebApi.Domain.Models.Enums;

namespace WebApi.Application.ProductData.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest<Product>
{
    public string? BarCode { get; set; }
    public Status Status { get; set; }
}

public class UpdateProductHandler(IProductRepository productRepository)
    : IRequestHandler<UpdateProductCommand, Product>
{
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            throw new Exception();
        }

        var product = new Product
        {
            BarCode = request.BarCode,
            Status = request.Status,
        };

        await productRepository.Update(product);

        return product;
    }
}