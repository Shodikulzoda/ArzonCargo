using ArzonCargo.Dtos.Response;
using ArzonCargo.Models;
using ArzonCargo.Models.Enums;
using ArzonCargo.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace ArzonCargo.Infrastructure.User.GetUser;

public class GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetAllUserQuery, IEnumerable<UserResponse>>
{
    public async Task<IEnumerable<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAll();

        var userResponses = users.Select(mapper.Map<UserResponse>);

        return userResponses;
    }
}