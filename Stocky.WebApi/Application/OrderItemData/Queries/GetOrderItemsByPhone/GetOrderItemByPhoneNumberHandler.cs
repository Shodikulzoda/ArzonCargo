using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderItemData.Queries.GetOrderItemsByPhone;

public record GetOrderItemByPhoneNumberQuery : IRequest<PaginatedList<OrderItem>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string PhoneNumber { get; init; }
}

public class GetOrderItemByPhoneNumberHandler(
    IOrderItemRepository orderItemRepository) :
    IRequestHandler<GetOrderItemByPhoneNumberQuery,
        PaginatedList<OrderItem>>
{
    public async Task<PaginatedList<OrderItem>> Handle(GetOrderItemByPhoneNumberQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedList = await PaginatedList<OrderItem>.CreateAsync(
            orderItemRepository.Queryable
                .Where(x => x.Order != null
                            && x.Order.User != null
                            && x.Order.User.Phone == request.PhoneNumber),
            request.Page,
            request.PageSize,
            cancellationToken);

        return new PaginatedList<OrderItem>(paginatedList.Items, paginatedList.TotalCount, paginatedList.PageNumber,
            paginatedList.TotalPages);
    }
}