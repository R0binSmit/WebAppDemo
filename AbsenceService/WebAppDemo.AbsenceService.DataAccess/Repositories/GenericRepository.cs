using Microsoft.EntityFrameworkCore;
using WebAppDemo.IGeneric;

namespace WebAppDemo.AbsenceService.DataAccess.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    internal readonly DatabaseContext _context;
    public GenericRepository(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);

        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public virtual async Task<bool> ExistsAsync(int id)
    {
        var entity = await GetAsync(id);
        _context.ChangeTracker.Clear();
        return entity != null;
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetAsync(int id)
    {
        T? entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
        {
            return null;
        }

        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
