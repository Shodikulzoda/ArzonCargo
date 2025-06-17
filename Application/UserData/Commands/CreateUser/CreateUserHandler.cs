using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.Models.Enums;
using MediatR;

namespace Application.UserData.Commands.CreateUser;

public record CreateUserCommand : IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
}

public class CreateUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<CreateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        
        var user = mapper.Map<User>(request);

        await userRepository.Add(user);

        return mapper.Map<UserResponse>(user);
    }
}