using System.Linq.Expressions;

namespace BlogCore.DataAccess.Repository.IRepository
{
    public interface IGenericRepository <T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        
        T GetById (int id);

        T GetFirstOrDefault(Expression<Func< T, bool>> filter = null, string includeProperties = null);

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);
    }
}
