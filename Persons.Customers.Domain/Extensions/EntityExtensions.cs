using Persons.Customers.Domain.Interfaces;
using System.Reflection;

namespace Persons.Customers.Domain.Extensions
{
    public static class EntityExtensions
    {
        public static void SetCreatedAtAndCreatedBy(this IEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = $"{Environment.MachineName}@{Environment.UserName}({Assembly.GetEntryAssembly()!.GetName().Name})";
        }

        public static void SetUpdatedAtAndUpdatedBy(this IEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = $"{Environment.MachineName}@{Environment.UserName}({Assembly.GetEntryAssembly()!.GetName().Name})";
        }
    }
}