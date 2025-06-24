using MediatR;
using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.UserData.Queries.Search;

public class SearchQuery : IRequest<List<User>>
{
    public string Text { get; set; }
}

public class SearchQueryHandler(IUserRepository userRepository)
    : IRequestHandler<SearchQuery, List<User>>
{
    public async Task<List<User>> Handle(SearchQuery query, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(query.Text))
        {
            return new List<User>();
        }

        var listUser = await userRepository.Queryable
            .Where(x => x.Name.Contains(query.Text)
                        || x.Phone.Contains(query.Text)
                        || x.Address.Contains(query.Text)
                        || x.Id.ToString().Contains(query.Text))
            .ToListAsync(cancellationToken);

        return listUser;
    }
}