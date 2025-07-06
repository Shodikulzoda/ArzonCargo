using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.UserData.Queries.GetUserBySearch;

public class SearchUserQuery : IRequest<List<User>>
{
    public string? Text { get; set; }
}

public class GetUserSearchQueryHandler(IUserRepository userRepository)
    : IRequestHandler<SearchUserQuery, List<User>>
{
    public async Task<List<User>> Handle(SearchUserQuery userQuery, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(userQuery.Text))
        {
            return [];
        }

        var listUser = await userRepository.Queryable
            .Where(x =>
                EF.Functions.Like(x.Name, $"%{userQuery.Text}%") ||
                EF.Functions.Like(x.Phone, $"%{userQuery.Text}%") ||
                EF.Functions.Like(x.Address, $"%{userQuery.Text}%") ||
                EF.Functions.Like(x.Id.ToString(), $"%{userQuery.Text}%"))
            .ToListAsync(cancellationToken);

        return listUser;
    }
}