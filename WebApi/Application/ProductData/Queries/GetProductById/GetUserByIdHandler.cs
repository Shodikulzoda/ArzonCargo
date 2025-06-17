using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.ProductData.Queries.GetProductById;

public record GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}

public class GetUserByIdHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            throw new Exception();
        }

        var product = await productRepository.GetById(request.Id);

        return product;
    }
}