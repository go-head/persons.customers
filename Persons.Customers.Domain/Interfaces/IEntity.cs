namespace Persons.Customers.Domain.Interfaces
{
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        string? CreatedBy { get; set; }

        bool IsTransient();
    }
}