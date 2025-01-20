namespace AcceptorsClub.Core.Models;

public class BaseEntity<TKey>
{
    public TKey Id { get; set; }
    public Guid Key { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}