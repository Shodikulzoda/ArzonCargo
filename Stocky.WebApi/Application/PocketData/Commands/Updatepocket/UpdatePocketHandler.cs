using MediatR;
using ReferenceClass.Models;
using ReferenceClass.Models.Enums;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Commands.Updatepocket;

public record UpdatePocketCommand : IRequest<Pocket>
{
    public int Id { get; set; }
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public double TotalAmount { get; set; }
    public Status Status { get; set; }
    public int UserId { get; set; }
}

public class UpdatePocketHandler(IPocketRepository pocketRepository)
    : IRequestHandler<UpdatePocketCommand, Pocket?>
{
    public async Task<Pocket?> Handle(UpdatePocketCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            return null;
        }

        var pocket = await pocketRepository.GetById(request.Id);
        if (pocket is null)
            return null;

        pocket.TotalWeight = request.TotalWeight;
        pocket.UserId = request.UserId;
        pocket.BarCode = request.BarCode;

        await pocketRepository.Update(pocket);

        return pocket;
    }
}