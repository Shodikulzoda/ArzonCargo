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

        if (userQuery.Text.Contains("@"))
        {
            var id = Convert.ToInt32(userQuery.Text.TrimStart('@'));

            var user = await userRepository.Queryable
                .Where(x => x.Id == id)
                .ToListAsync(cancellationToken);
            return user;
        }

        var text = userQuery.Text.ToLower();

        var listUser = await userRepository.Queryable
            .Where(x =>
                EF.Functions.Like(x.Name.ToLower(), $"%{text}%") ||
                EF.Functions.Like(x.Phone.ToLower(), $"%{text}%") ||
                EF.Functions.Like(x.Address.ToLower(), $"%{text}%"))
            .ToListAsync(cancellationToken);

        return listUser;
    }
}