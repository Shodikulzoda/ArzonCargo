using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UserData.Queries.UsersByPagination;

public record UsersByPaginationQuery(int Page, int PageSize) : IRequest<IEnumerable<UserResponse>>;

public class UsersByPaginationQueryHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UsersByPaginationQuery, IEnumerable<UserResponse>>
{
    public async Task<IEnumerable<UserResponse>> Handle(UsersByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var users = await userRepository
            .GetUserByPagination(request.Page, request.PageSize, cancellationToken);

        return mapper.Map<IEnumerable<UserResponse>>(users);
    }
}