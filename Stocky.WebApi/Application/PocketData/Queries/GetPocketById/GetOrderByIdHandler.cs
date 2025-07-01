using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetPocketById;

public record GetPocketByIdQuery : IRequest<Pocket>
{
    public int Id { get; set; }
}

public class GetOrderByIdHandler(IPocketRepository pocketRepository)
    : IRequestHandler<GetPocketByIdQuery, Pocket>
{
    public async Task<Pocket> Handle(GetPocketByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await pocketRepository.GetById(request.Id);
        if (result is null)
        {
            throw new Exception("Order not found");
        }

        return result;
    }
}