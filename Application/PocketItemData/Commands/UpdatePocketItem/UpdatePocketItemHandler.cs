using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.PocketItemData.Commands.UpdatePocketItem;

public record UpdatePocketItemCommand : IRequest<PocketItemResponse>
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}

public class UpdatePocketItemHandler(IPocketItemRepository pocketItemRepository, IMapper mapper)
    : IRequestHandler<UpdatePocketItemCommand, PocketItemResponse>
{
    public async Task<PocketItemResponse> Handle(UpdatePocketItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId<=0 || request.OrderId <= 0)
        {
            throw new Exception();
        }

        var product = mapper.Map<PocketItem>(request);

        await pocketItemRepository.Update(product);

        return mapper.Map<PocketItemResponse>(product);
    }
}