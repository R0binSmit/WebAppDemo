namespace WebAppDemo.AbsenceService.IDataAccess;

public interface IGenericRepository<T>
{
    Task<T?> GetAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task DeleteAsync(int id);
    Task UpdateAsync(T entity);
    Task<bool> ExistsAsync(int id);
}