using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.UserData.Queries.UsersByPagination;

public record UsersByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<User>>;

public class UsersByPaginationQueryHandler(IUserRepository userRepository)
    : IRequestHandler<UsersByPaginationQuery, PaginatedList<User>>
{
    public async Task<PaginatedList<User>> Handle(UsersByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var userPagination = await PaginatedList<User>.CreateAsync(
            userRepository.Queryable,
            request.Page,
            request.PageSize, cancellationToken);

        return new PaginatedList<User>(userPagination.Items, userPagination.TotalCount, userPagination.PageNumber,
            userPagination.TotalPages);
    }
}