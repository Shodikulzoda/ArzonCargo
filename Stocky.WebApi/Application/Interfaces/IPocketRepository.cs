using Stocky.Shared.Models;

namespace Stocky.WebApi.Application.Interfaces;

public interface IPocketRepository : IBaseRepository<Pocket>
{
    Task<Pocket> Add(Pocket pocket);
    Task<IEnumerable<Pocket>> GetAll();
    Task<Pocket> Update(Pocket pocket);
    Task<bool> Delete(int id);
    
    Task<Pocket?> GetById(int id);

    Task<Pocket> GetByUserId(int id);
    
    Task<int> Count();
    Task<IEnumerable<Pocket>> GetOrderByPagination(int page, int pageSize, CancellationToken cancellationToken);
}