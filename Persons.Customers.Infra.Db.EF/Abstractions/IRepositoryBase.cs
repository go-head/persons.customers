using System.Linq.Expressions;

namespace Persons.Customers.Infra.Db.EF.Abstractions
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Delete(object id);

        void Delete(TEntity entityToDelete);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");

        Task<TEntity> GetByID(object id);

        Task<TEntity> InserAsync(TEntity entity);

        void Update(TEntity entityToUpdate);
    }
}