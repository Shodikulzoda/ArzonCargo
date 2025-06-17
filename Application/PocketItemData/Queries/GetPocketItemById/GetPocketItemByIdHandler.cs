using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.PocketItemData.Queries.GetPocketItemById;

public record GetPocketItemByIdQuery : IRequest<PocketItemResponse>
{
    public int Id { get; set; }
}

public class GetPocketItemrByIdHandler(IPocketItemRepository pocketItemRepository, IMapper mapper)
    : IRequestHandler<GetPocketItemByIdQuery, PocketItemResponse>
{
    public async Task<PocketItemResponse> Handle(GetPocketItemByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            throw new Exception();
        }

        var product = await pocketItemRepository.GetById(request.Id);

        return mapper.Map<PocketItemResponse>(product);
    }
}