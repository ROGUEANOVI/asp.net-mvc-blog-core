using BlogCore.Models;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BlogCore.BusinessLogic.Service.IService
{
    public interface ICategoryService 
    {
        Task<IEnumerable<Category>> GetAllCategories(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = null);

        IEnumerable<SelectListItem> GetCategoriesList();

        Task<Category?> GetCategoryById(int id);

        Task<Category?> GetCategoryFirstOrDefault(Expression<Func<Category, bool>> filter = null, string includeProperties = null);

        Task AddCategory(Category category);

        Task UpdateCategory(Category category);

        Task RemoveCategory(int id);

        void RemoveCategory(Category category);
    }
}
