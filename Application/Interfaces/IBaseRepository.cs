namespace Application.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public IQueryable<T> Querable { get; set; }

    public Task<bool> Delete(int id);
}