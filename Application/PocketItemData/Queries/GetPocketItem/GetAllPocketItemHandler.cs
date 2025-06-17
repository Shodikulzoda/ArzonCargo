using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.PocketItemData.Queries.GetPocketItem;

public record GetAllPocketItemQuery : IRequest<IEnumerable<PocketItemResponse>>;

public class GetAllPocketItemHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetAllPocketItemQuery, IEnumerable<PocketItemResponse>>
{
    public async Task<IEnumerable<PocketItemResponse>> Handle(GetAllPocketItemQuery request,
        CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAll();

        var productResponses = products.Select(mapper.Map<PocketItemResponse>);

        return productResponses;
    }
}