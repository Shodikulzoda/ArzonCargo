using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetPocketByPagination;

public record GetPocketByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<Pocket>>;

public class GetPocketByPaginationQueryHandler(IPocketRepository pocketRepository)
    : IRequestHandler<GetPocketByPaginationQuery, PaginatedList<Pocket>>
{
    public async Task<PaginatedList<Pocket>> Handle(GetPocketByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var pockets = await pocketRepository
            .GetOrderByPagination(request.Page, request.PageSize, cancellationToken);

        var totalCount = await pocketRepository.Count();

        var listPockets = pockets
            .Select(x => new Pocket()
            {
                BarCode = x.BarCode,
                Status = x.Status,
                TotalAmount = x.TotalAmount,
                TotalWeight = x.TotalWeight,
                UserId = x.UserId,
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                PocketItems = x.PocketItems,
            }).ToList();

        return new PaginatedList<Pocket>(listPockets, totalCount, request.Page, request.PageSize);
    }
}