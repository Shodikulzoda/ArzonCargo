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
            return new List<User>();
        }

        var search = userQuery.Text.ToLower();
        var listUser = await userRepository.Queryable
            .Where(x => x.Name.ToLower().Contains(search)
                        || x.Phone.ToLower().Contains(search)
                        || x.Address.ToLower().Contains(search)
                        || x.Id.ToString().Contains(search))
            .ToListAsync(cancellationToken);

        return listUser;
    }
}