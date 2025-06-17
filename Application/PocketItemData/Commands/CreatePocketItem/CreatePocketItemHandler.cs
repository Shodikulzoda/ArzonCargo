using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.PocketItemData.Commands.CreatePocketItem;

public record CreatePocketItemCommand : IRequest<PocketItemResponse>
{ 
    public int ProductId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int OrderId { get; set; }
}

public class CreatePocketItemHandler(IPocketItemRepository pocketItemRepository, IMapper mapper)  : IRequestHandler<CreatePocketItemCommand,PocketItemResponse>
{
    public async Task<PocketItemResponse> Handle(CreatePocketItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0|| request.OrderId <= 0)
        {
            throw new Exception();
        }

        var product = mapper.Map<PocketItem>(request);

        await pocketItemRepository.Add(product);

        return mapper.Map<PocketItemResponse>(product);
    }
}