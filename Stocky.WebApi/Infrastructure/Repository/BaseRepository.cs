using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Databases;

namespace Stocky.WebApi.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public IQueryable<T> Queryable { get; set; }

    public BaseRepository(ApplicationContext context)
    {
        Queryable = context.Set<T>().AsQueryable();
    }
}