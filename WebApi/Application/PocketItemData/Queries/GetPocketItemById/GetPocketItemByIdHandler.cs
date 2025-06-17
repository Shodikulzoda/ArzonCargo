using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.PocketItemData.Queries.GetPocketItemById;

public record GetPocketItemByIdQuery : IRequest<PocketItem>
{
    public int Id { get; set; }
}

public class GetPocketItemrByIdHandler(IPocketItemRepository pocketItemRepository)
    : IRequestHandler<GetPocketItemByIdQuery, PocketItem>
{
    public async Task<PocketItem> Handle(GetPocketItemByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            throw new Exception();
        }

        var product = await pocketItemRepository.GetById(request.Id);

        return product;
    }
}