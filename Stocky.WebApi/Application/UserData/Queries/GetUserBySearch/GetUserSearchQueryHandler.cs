using MediatR;
using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.UserData.Queries.Search;

public class SearchQuery : IRequest<List<User>>
{
    public string? Text { get; set; }
}

public class GetUserSearchQueryHandler(IUserRepository userRepository)
    : IRequestHandler<SearchQuery, List<User>>
{
    public async Task<List<User>> Handle(SearchQuery query, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(query.Text))
        {
            return new List<User>();
        }

        var search = query.Text.ToLower();
        var listUser = await userRepository.Queryable
            .Where(x => x.Name.ToLower().Contains(search)
                        || x.Phone.ToLower().Contains(search)
                        || x.Address.ToLower().Contains(search)
                        || x.Id.ToString().Contains(search))
            .ToListAsync(cancellationToken);

        return listUser;
    }
}