using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetPocketByUserId;

public record GetPocketsByUserIdQuery : IRequest<PaginatedList<Pocket>>
{
    public int UserId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class GetOrdersByUserIdHandler(IPocketRepository pocketRepository)
    : IRequestHandler<GetPocketsByUserIdQuery, PaginatedList<Pocket>>
{
    public async Task<PaginatedList<Pocket>> Handle(GetPocketsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var ordersByUserId = await PaginatedList<Pocket>.CreateAsync(
            pocketRepository.Queryable.Where(x => x.UserId == request.UserId),
            request.Page,
            request.PageSize, cancellationToken);

        return new PaginatedList<Pocket>(ordersByUserId.Items, ordersByUserId.TotalCount, ordersByUserId.PageNumber,
            ordersByUserId.TotalPages);
    }
}