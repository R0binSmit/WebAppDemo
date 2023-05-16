using Microsoft.EntityFrameworkCore;
using WebAppDemo.BusinessLogic.Interfaces.Repositories;
using WebAppDemo.DataAccess;

namespace WebAppDemo.BusinessLogic.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DatabaseContext _context;
    public GenericRepository(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);

        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();

    }

    public async Task<T?> GetAsync(int id)
    {
        T? entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
        {
            return null;
        }

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
