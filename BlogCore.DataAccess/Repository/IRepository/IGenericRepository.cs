using System.Linq.Expressions;

namespace BlogCore.DataAccess.Repository.IRepository
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        
        Task<T?> GetById (int id);

        Task<T?> GetFirstOrDefault(Expression<Func< T, bool>> filter = null, string includeProperties = null);

        Task Add(T entity);

        Task Remove(int id);

        void Remove(T entity);
    }
}
