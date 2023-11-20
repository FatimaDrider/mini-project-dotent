using Domain.Common;

namespace Domain.Entities;

public class Category : BaseEntity<int>
{
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}