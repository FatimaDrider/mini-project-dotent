using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsyncWithIncludes()
    {
        return await _context.Products.AsNoTracking().Include(x => x.Category).ToListAsync();
    }
}