using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetPocketByPagination;

public record GetPocketByPaginationQuery(
    int Page,
    int PageSize,
    DateTime? DateFrom,
    DateTime? DateTo) : IRequest<PaginatedList<Pocket>>;

public class GetPocketByPaginationQueryHandler(IPocketRepository pocketRepository)
    : IRequestHandler<GetPocketByPaginationQuery, PaginatedList<Pocket>>
{
    public async Task<PaginatedList<Pocket>> Handle(GetPocketByPaginationQuery request,
        CancellationToken cancellationToken)

    {
        var query = pocketRepository.Queryable;

        query = pocketRepository.Queryable
            .Include(x => x.User);

        if (request.DateFrom.HasValue)
        {
            query = query.Where(x => x.CreatedAt >= request.DateFrom.Value);
        }

        if (request.DateTo.HasValue)
        {
            query = query.Where(x => x.CreatedAt <= request.DateTo.Value);
        }

        var productPagination = await PaginatedList<Pocket>.CreateAsync(
            query,
            request.Page,
            request.PageSize,
            cancellationToken);

        return new PaginatedList<Pocket>(
            productPagination.Items,
            productPagination.TotalCount,
            productPagination.PageNumber,
            productPagination.TotalPages);
    }
}