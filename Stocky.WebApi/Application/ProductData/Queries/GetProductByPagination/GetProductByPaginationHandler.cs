using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ProductData.Queries.GetProductByPagination;

public record GetProductByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<Product>>;

public class GetProductByPaginationHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByPaginationQuery, PaginatedList<Product>>
{
    public async Task<PaginatedList<Product>> Handle(GetProductByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var userPagination = await PaginatedList<Product>.CreateAsync(
            productRepository.Queryable,
            request.Page,
            request.PageSize, cancellationToken);

        return new PaginatedList<Product>(userPagination.Items, userPagination.TotalCount, userPagination.PageNumber,
            userPagination.TotalPages);
    }
}