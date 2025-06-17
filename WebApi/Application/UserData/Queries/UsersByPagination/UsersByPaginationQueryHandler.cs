using MediatR;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.UserData.Queries.UsersByPagination;

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

        List<User> userResponses = users
            .Select(user => new User
            {
                Id = user.Id,
                Address = user.Address,
                Phone = user.Phone,
                Name = user.Name,
                Role = user.Role
            })
            .ToList();

        return new PaginatedList<User>(userResponses, totalCount, request.Page, request.PageSize);
    }
}