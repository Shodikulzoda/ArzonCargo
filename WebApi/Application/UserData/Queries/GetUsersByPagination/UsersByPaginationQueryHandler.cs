using MediatR;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.UserData.Queries.GetUsersByPagination;

public record UsersByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<User>>;

public class UsersByPaginationQueryHandler(IUserRepository userRepository)
    : IRequestHandler<UsersByPaginationQuery, PaginatedList<User>>
{
    public async Task<PaginatedList<User>> Handle(UsersByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var users = await userRepository
            .GetUserByPagination(request.Page, request.PageSize, cancellationToken);

        var totalCount = await userRepository.Count();

        return new PaginatedList<User>(users, totalCount, request.Page, request.PageSize);
    }
}