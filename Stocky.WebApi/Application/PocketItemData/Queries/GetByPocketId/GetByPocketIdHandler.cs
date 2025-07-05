using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketItemData.Queries.GetByPocketId;

public record GetByPocketIdQuery : IRequest<PaginatedList<PocketItem>>
{
    public int PocketId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class GetOrdersByUserIdHandler(IPocketItemRepository pocketItemRepository)
    : IRequestHandler<GetByPocketIdQuery, PaginatedList<PocketItem>>
{
    public async Task<PaginatedList<PocketItem>> Handle(GetByPocketIdQuery request, CancellationToken cancellationToken)
    {
        var ordersByUserId = await PaginatedList<PocketItem>.CreateAsync(
            pocketItemRepository.Queryable.Where(x => x.PocketId == request.PocketId),
            request.Page,
            request.PageSize, cancellationToken);

        return new PaginatedList<PocketItem>(ordersByUserId.Items, ordersByUserId.TotalCount, ordersByUserId.PageNumber,
            ordersByUserId.TotalPages);
    }
}