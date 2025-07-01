using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Commands.Createpocket;

public record CreatePocketCommand : IRequest<Pocket>
{
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
}

public class CreatePocketHandler(IPocketRepository pocketRepository, IUserRepository userRepository)
    : IRequestHandler<CreatePocketCommand, Pocket?>
{
    public async Task<Pocket?> Handle(CreatePocketCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.UserId);
        if (user is null)
            throw new Exception("User not found");

        if (string.IsNullOrEmpty(request.BarCode))
        {
            return null;
        }

        var pocket = new Pocket()
        {
            BarCode = request.BarCode,
            TotalWeight = request.TotalWeight,
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow
        };

        return await pocketRepository.Add(pocket);
    }
}