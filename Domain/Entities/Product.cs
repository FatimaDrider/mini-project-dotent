using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class Product : BaseEntity<int>
{
    public Product(string name, string description, decimal price, int categorieId)
    {
        Name = name;
        Description = description;
        Price = price;
        CategorieId = categorieId;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    [ForeignKey("CategoryId")] public int CategorieId { get; set; }

    public virtual Category Category { get; set; }
}