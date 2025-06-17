using Application.Dtos.Response;
using Application.Interfaces;
using Application.ProductData.Commands.CreateProduct;
using AutoMapper;
using Domain.Models;
using Domain.Models.Enums;
using MediatR;

namespace Application.ProductData.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest<ProductResponse>
{
    public string? BarCode { get; set; }
    public Status Status { get; set; }
}

public class UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            throw new Exception();
        }

        var product = mapper.Map<Product>(request);

        await productRepository.Update(product);

        return mapper.Map<ProductResponse>(product);
    }
}