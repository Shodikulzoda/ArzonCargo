using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.ProductData.Commands.CreateProduct;

public record CreateProductCommand : IRequest<ProductResponse>
{
    public string? BarCode { get; set; }
}

public class CreateProductHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<CreateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            throw new Exception();
        }

        var product = mapper.Map<Product>(request);

        await productRepository.Add(product);

        return mapper.Map<ProductResponse>(product);
    }
}