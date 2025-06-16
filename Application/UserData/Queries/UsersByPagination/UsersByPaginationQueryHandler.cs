using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UserData.Queries.UsersByPagination;

public class UsersByPaginationQueryHandler : IRequestHandler<UsersByPaginationQuery, List<UserResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UsersByPaginationQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public Task<List<UserResponse>> Handle(UsersByPaginationQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}