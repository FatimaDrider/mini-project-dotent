using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;


namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    public GenericRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsyFnc()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        _context.Remove(await GetByIdAsync(id));
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        return _context.SaveChangesAsync();
    }

    public async Task<bool> Exisit(int id)
    {
        var entry = await GetByIdAsync(id);
        return entry != null;
    }
}