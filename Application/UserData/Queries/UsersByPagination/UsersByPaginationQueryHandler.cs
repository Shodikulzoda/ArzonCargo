using Application.Common;
using Application.Dtos.Response;
using Application.Interfaces;
using MediatR;

namespace Application.UserData.Queries.UsersByPagination;

public record UsersByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<UserResponse>>;

public class UsersByPaginationQueryHandler(IUserRepository userRepository)
    : IRequestHandler<UsersByPaginationQuery, PaginatedList<UserResponse>>
{
    public async Task<PaginatedList<UserResponse>> Handle(UsersByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var users = await userRepository
            .GetUserByPagination(request.Page, request.PageSize, cancellationToken);

        var totalCount = await userRepository.Count();

        List<UserResponse> userResponses = users
            .Select(user => new UserResponse
            {
                Address = user.Address,
                Phone = user.Phone,
                Name = user.Name,
                Role = user.Role
            })
            .ToList();
        
        return new PaginatedList<UserResponse>(userResponses, totalCount, request.Page, request.PageSize);
    }
}