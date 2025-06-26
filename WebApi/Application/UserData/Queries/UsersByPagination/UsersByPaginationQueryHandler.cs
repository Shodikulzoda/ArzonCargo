using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;

namespace WebApi.Application.UserData.Queries.UsersByPagination;

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