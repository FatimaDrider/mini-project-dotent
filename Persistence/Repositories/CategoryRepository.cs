using Domain.Contracts;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, IGenericRepository<Category>, ICatergoryRepository
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}