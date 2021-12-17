using DidarCodeChallenge.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace DidarCodeChallenge.Api.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;
    private readonly DbSet<TEntity> _db;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _db = _context.Set<TEntity>();
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _db.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

}