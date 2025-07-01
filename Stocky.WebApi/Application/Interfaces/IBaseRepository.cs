namespace Stocky.WebApi.Application.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public IQueryable<T> Queryable { get; set; }
}