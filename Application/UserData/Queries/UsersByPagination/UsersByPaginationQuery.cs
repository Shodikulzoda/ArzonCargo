using Application.Dtos.Response;
using MediatR;

namespace Application.UserData.Queries.UsersByPagination;

public record UsersByPaginationQuery(int Page, int PageSize) : IRequest<List<UserResponse>>;