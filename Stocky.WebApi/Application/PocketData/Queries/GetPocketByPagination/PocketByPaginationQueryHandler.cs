using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetPocketByPagination;

public record GetPocketByPaginationQuery : IRequest<PaginatedList<Pocket>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class GetPocketByPaginationQueryHandler(IPocketRepository pocketRepository)
    : IRequestHandler<GetPocketByPaginationQuery, PaginatedList<Pocket>>
{
    public async Task<PaginatedList<Pocket>> Handle(GetPocketByPaginationQuery request,
        CancellationToken cancellationToken)
    {
         // pocketRepository.Queryable
         //    .Include(x => x.User);
        
        var userPagination = await PaginatedList<Pocket>.CreateAsync(
            pocketRepository.Queryable,
            request.Page,
            request.PageSize, cancellationToken);

        return new PaginatedList<Pocket>(userPagination.Items, userPagination.TotalCount, userPagination.PageNumber,
            userPagination.TotalPages);
    }
}