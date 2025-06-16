using AutoMapper;
using MediatR;
using WebApi.Dtos.Response;
using WebApi.Repository.Interfaces;

namespace WebApi.UserData.Queries.UserById;

public record UserByIdQuery(Guid Id) : IRequest<UserResponse>;

public class UserByIdQueryHandler : IRequestHandler<UserByIdQuery, UserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(UserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);

        return _mapper.Map<UserResponse>(user);
    }
}