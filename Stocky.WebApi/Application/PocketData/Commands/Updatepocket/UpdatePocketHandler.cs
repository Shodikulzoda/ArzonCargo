using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Commands.Updatepocket;

public record UpdatePocketCommand : IRequest<Pocket>
{
    public int Id { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
}

public class UpdatePocketHandler(IPocketRepository pocketRepository, IConfiguration configuration)
    : IRequestHandler<UpdatePocketCommand, Pocket?>
{
    public async Task<Pocket?> Handle(UpdatePocketCommand request, CancellationToken cancellationToken)
    {
        var t = configuration.GetValue<int>("SumOfKg:SumOfPerKg");
        var pocket = await pocketRepository.GetById(request.Id);
        if (pocket is null)
        {
            return null;
        }

        pocket.TotalWeight = request.TotalWeight;
        pocket.UserId = request.UserId;
        pocket.TotalAmount = request.TotalWeight * t;

        await pocketRepository.Update(pocket);

        return pocket;
    }
}