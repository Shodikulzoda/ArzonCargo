using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.ProductData.Queries.GetUser;

public record GetAllProductQuery : IRequest<IEnumerable<ProductResponse>>;

public class GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetAllProductQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductQuery request,
        CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAll();

        var productResponses = products.Select(mapper.Map<ProductResponse>);

        return productResponses;
    }
}