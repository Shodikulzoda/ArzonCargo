using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.ProductData.Queries.GetUserById;

public record GetProductByIdQuery : IRequest<ProductResponse>
{
    public int Id { get; set; }
}

public class GetUserByIdHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            throw new Exception();
        }

        var product = await productRepository.GetById(request.Id);

        return mapper.Map<ProductResponse>(product);
    }
}