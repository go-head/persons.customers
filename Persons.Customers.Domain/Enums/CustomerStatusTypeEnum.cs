using Persons.Customers.Domain.Abstractions;

namespace Persons.Customers.Domain.Enums
{
    public class CustomerStatusTypeEnum : Enumeration
    {
        public static CustomerStatusTypeEnum PENDING => new(1, nameof(PENDING));
        public static CustomerStatusTypeEnum ACTIVE => new(2, nameof(ACTIVE));
        public static CustomerStatusTypeEnum BLOCKED => new(3, nameof(BLOCKED));
        public static CustomerStatusTypeEnum CANCELED => new(4, nameof(CANCELED));

        public CustomerStatusTypeEnum(int id, string name)
            : base(id, name)
        {
        }
    }
}