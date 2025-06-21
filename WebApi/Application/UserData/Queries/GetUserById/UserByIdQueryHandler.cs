using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.UserData.Queries.GetUserById;

public record UserByIdQuery : IRequest<User>
{
    public int Id { get; set; }
}

public class UserByIdQueryHandler(IUserRepository userRepository)
    : IRequestHandler<UserByIdQuery, User?
    >
{
    public async Task<User?> Handle(UserByIdQuery request, CancellationToken cancellationToken)
    {
        return await userRepository.GetById(request.Id) ?? null;
    }
}