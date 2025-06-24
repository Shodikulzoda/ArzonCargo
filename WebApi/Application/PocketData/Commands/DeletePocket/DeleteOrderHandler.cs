using MediatR;
using WebApi.Application.Interfaces;

namespace WebApi.Application.PocketData.Commands.DeletePocket;

public record DeletePocketCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeletePocketHandler(IPocketRepository pocketRepository)
    : IRequestHandler<DeletePocketCommand, bool>
{
    public async Task<bool> Handle(DeletePocketCommand request, CancellationToken cancellationToken)
    {
        var result = await pocketRepository.Delete(request.Id);

        return result;
    }
}