using MediatR;
using ReferenceClass.Models;
using ReferenceClass.Models.Enums;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest<Product>
{
    public int Id { get; set; }
    public Status Status { get; set; }
}

public class UpdateProductHandler(IProductRepository productRepository)
    : IRequestHandler<UpdateProductCommand, Product>
{
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Status.ToString()))
        {
            throw new Exception();
        }

        var product = await productRepository.GetById(request.Id);
        if (product is null)
        {
            return null;
        }

        product.Status = request.Status;

        await productRepository.Update(product);

        return product;
    }
}