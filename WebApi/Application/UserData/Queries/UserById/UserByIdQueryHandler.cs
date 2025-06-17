using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.UserData.Queries.UserById;

public record UserByIdQuery : IRequest<User>
{
    public int Id { get; set; }
}

public class UserByIdQueryHandler(IUserRepository userRepository)
    : IRequestHandler<UserByIdQuery, User
    >
{
    public async Task<User> Handle(UserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.Id);

        return user;
    }
}