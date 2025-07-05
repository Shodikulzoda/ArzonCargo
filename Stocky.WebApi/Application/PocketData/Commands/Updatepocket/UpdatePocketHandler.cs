using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Commands.Updatepocket;

public record UpdatePocketCommand : IRequest<Pocket>
{
    public int Id { get; set; }
    public double TotalWeight { get; set; }
    public double TotalAmount { get; set; }
    public int UserId { get; set; }
}

public class UpdatePocketHandler(IPocketRepository pocketRepository)
    : IRequestHandler<UpdatePocketCommand, Pocket?>
{
    public async Task<Pocket?> Handle(UpdatePocketCommand request, CancellationToken cancellationToken)
    {
        var pocket = await pocketRepository.GetById(request.Id);
        if (pocket is null)
            return null;

        pocket.TotalWeight = request.TotalWeight;
        pocket.UserId = request.UserId;
        pocket.TotalAmount = request.TotalAmount;

        await pocketRepository.Update(pocket);

        return pocket;
    }
}