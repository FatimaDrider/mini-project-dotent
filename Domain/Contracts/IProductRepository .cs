using Domain.Entities;

namespace Domain.Contracts;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetAllAsyncWithIncludes();
}