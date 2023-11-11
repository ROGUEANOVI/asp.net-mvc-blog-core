using BlogCore.DataAccess.Repository.IRepository;
using BlogCore.Models;
using BlogCore.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace BlogCore.DataAccess.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCategoriesList()
        {
            return _context.Categories.Select(c => new SelectListItem() 
                {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                }
            );
        }

        public async Task Update(Category category)
        {
            var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
            if (categoryEntity != null)
            {
                categoryEntity.Name = category.Name;
                categoryEntity.Order = category.Order;
            }
        }
    }
}
