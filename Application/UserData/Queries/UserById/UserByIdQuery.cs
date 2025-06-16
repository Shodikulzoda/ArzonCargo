using Application.Dtos.Response;
using MediatR;

namespace Application.UserData.Queries.UserById;

public record UserByIdQuery(int Id) : IRequest<UserResponse>;