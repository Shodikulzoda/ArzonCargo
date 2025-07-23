using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Queries.GetProductByPagination;

public record GetProductByPaginationQuery(
    int Page,
    int PageSize,
    DateTime? DateFrom,
    DateTime? DateTo
) : IRequest<PaginatedList<Product>>;

public class GetProductByPaginationHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByPaginationQuery, PaginatedList<Product>>
{
    public async Task<PaginatedList<Product>> Handle(GetProductByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var query = productRepository.Queryable;

        if (request.DateFrom.HasValue)
        {
            query = query.Where(x => x.CreatedAt >= request.DateFrom.Value);
        }

        if (request.DateTo.HasValue)
        {
            query = query.Where(x => x.CreatedAt <= request.DateTo.Value);
        }

        var productPagination = await PaginatedList<Product>.CreateAsync(
            query,
            request.Page,
            request.PageSize,
            cancellationToken);

        return new PaginatedList<Product>(
            productPagination.Items,
            productPagination.TotalCount,
            productPagination.PageNumber,
            productPagination.TotalPages);
    }
}