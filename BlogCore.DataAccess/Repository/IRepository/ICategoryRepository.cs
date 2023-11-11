using BlogCore.Models;
using System.Web.Mvc;

namespace BlogCore.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoriesList();

        Task Update(Category category);
    }
}
