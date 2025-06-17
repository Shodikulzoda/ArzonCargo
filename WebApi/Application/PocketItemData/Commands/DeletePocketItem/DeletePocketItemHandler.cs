using MediatR;
using WebApi.Application.Interfaces;

namespace Appplication.PocketItemData.Commands.DeletePocketItem;

public record DeletePocketItemCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeletePocketItemHandler(IPocketItemRepository pocketItemRepository)
    : IRequestHandler<DeletePocketItemCommand, bool>
{
    public async Task<bool> Handle(DeletePocketItemCommand request, CancellationToken cancellationToken)
    {
        return await pocketItemRepository.Delete(request.Id);
    }
}