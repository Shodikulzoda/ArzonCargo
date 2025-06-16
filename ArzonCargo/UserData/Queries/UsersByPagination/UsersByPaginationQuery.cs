using ArzonCargo.Dtos.Response;
using ArzonCargo.Infrastructure.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArzonCargo.UserData.Queries.UsersByPagination;

public record UsersByPaginationQuery(int Page, int PageSize) : IRequest<List<UserResponse>>;

public class UsersByPaginationQueryHandler : IRequestHandler<UsersByPaginationQuery, List<UserResponse>>
{
    private readonly IMapper _mapper;
    private readonly ApplicationContext _context;

    public UsersByPaginationQueryHandler(ApplicationContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<UserResponse>> Handle(UsersByPaginationQuery request, CancellationToken cancellationToken)
    {
        await _context.Users.CountAsync(cancellationToken);
        var users = await _context.Users.Skip(request.Page * request.PageSize).Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<UserResponse>>(users);
    }
}