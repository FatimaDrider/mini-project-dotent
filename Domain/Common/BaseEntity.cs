namespace Domain.Common;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedData { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedData { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}