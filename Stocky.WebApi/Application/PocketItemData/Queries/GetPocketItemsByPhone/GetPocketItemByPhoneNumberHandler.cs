using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItemsByPhone;

public record GetPocketItemByPhoneNumberQuery : IRequest<PaginatedList<PocketItem>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string PhoneNumber { get; init; }
}

public class GetPocketItemByPhoneNumberHandler(
    IPocketItemRepository pocketItemRepository) :
    IRequestHandler<GetPocketItemByPhoneNumberQuery,
        PaginatedList<PocketItem>>
{
    public async Task<PaginatedList<PocketItem>> Handle(GetPocketItemByPhoneNumberQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedList = await PaginatedList<PocketItem>.CreateAsync(
            pocketItemRepository.Queryable
                .Where(x => x.Pocket != null
                            && x.Pocket.User != null
                            && x.Pocket.User.Phone == request.PhoneNumber),
            request.Page,
            request.PageSize,
            cancellationToken);

        return new PaginatedList<PocketItem>(paginatedList.Items, paginatedList.TotalCount, paginatedList.PageNumber,
            paginatedList.TotalPages);
    }
}