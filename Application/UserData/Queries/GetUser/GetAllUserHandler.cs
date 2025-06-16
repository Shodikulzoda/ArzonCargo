using Application.Dtos.Response;
using AutoMapper;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.UserData.Queries.GetUser;



public class GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetAllUserQuery, IEnumerable<UserResponse>>
{
    public async Task<IEnumerable<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAll();

        var userResponses = users.Select(((IMapperBase)mapper).Map<UserResponse>);

        return userResponses;
    }
}