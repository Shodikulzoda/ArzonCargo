using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.PocketItemData.Commands.DeletePocketItem;

public record DeletePocketItemCommand : IRequest<PocketItemResponse>
{
    public int Id { get; set; }
}

public class DeletePocketItemHandler(IPocketItemRepository pocketItemRepository, IMapper mapper)
    : IRequestHandler<DeletePocketItemCommand, PocketItemResponse?>
{
    public async Task<PocketItemResponse?> Handle(DeletePocketItemCommand request, CancellationToken cancellationToken)
    {
        var product = await pocketItemRepository.GetById(request.Id);
        if (product is null)
        {
            return null;
        }

        await pocketItemRepository.Update(product);

        return mapper.Map<PocketItemResponse>(product);
    }
}