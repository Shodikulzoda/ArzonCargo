using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public IQueryable<T> Queryable { get; set; }

    private readonly ApplicationContext _context;

    public BaseRepository(ApplicationContext context)
    {
        Queryable = context.Set<T>().AsQueryable();
        _context = context;
    }
}