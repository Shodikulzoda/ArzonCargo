using Application.Dtos.Response;
using AutoMapper;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.UserData.Queries.UserById;

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