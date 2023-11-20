namespace Domain.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsyFnc();
    Task CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task UpdateAsync(T entity);
    Task<bool> Exisit(int id);
}