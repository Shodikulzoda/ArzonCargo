using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UserData.Queries.UserById;

public record UserByIdQuery(int Id) : IRequest<UserResponse>;

public class UserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UserByIdQuery, UserResponse>
{
    public async Task<UserResponse> Handle(UserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.Id);

        return mapper.Map<UserResponse>(user);
    }
}