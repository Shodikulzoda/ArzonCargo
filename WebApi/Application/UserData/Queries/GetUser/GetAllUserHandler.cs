using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.UserData.Queries.GetUser;

public record GetAllUserQuery : IRequest<IEnumerable<User>>;

public class GetAllUserHandler(IUserRepository userRepository)
    : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAll();

        return users;
    }
}