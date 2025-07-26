using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Application.OrderItemData.Queries.GetAllOrderItem;

namespace Stocky.WebApi.Application.AuthenticationData.Queries;

public record GetUserNameByIdQuery : IRequest<UsernameResponse>
{
    public int Id { get; init; }
}
public class UsernameResponse
{
    public string? UserName { get; set; }
}

public class GetUserNameById( IAuthRepository authRepository)
    : IRequestHandler<GetUserNameByIdQuery, UsernameResponse>
{
    public async Task<UsernameResponse> Handle(GetUserNameByIdQuery query, CancellationToken cancellationToken)
    {
        var userName = new UsernameResponse()
        {
            UserName = await authRepository.GetUserNameById(query.Id)
        };
        
        return userName;
    }
}