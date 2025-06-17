using MediatR;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.ProductData.Queries.GetProductByPagination;

public record GetProductByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<Product>>;

public class GetProductByPaginationHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByPaginationQuery, PaginatedList<Product>>
{
    public async Task<PaginatedList<Product>> Handle(GetProductByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var productByPagination =
            await productRepository.GetProductByPagination(request.Page, request.PageSize, cancellationToken);

        var count = await productRepository.Count();

        return new PaginatedList<Product>(productByPagination, count, request.Page, request.PageSize);
    }
}