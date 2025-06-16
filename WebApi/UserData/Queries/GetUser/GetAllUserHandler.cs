using AutoMapper;
using MediatR;
using WebApi.Dtos.Response;
using WebApi.Repository.Interfaces;

namespace WebApi.UserData.Queries.GetUser;



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