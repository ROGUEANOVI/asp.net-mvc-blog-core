using BlogCore.BusinessLogic.Service.IService;
using BlogCore.DataAccess.Repository.IRepository;
using BlogCore.Models;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BlogCore.BusinessLogic.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCategory(Category category)
        {
            await _unitOfWork.Category.Add(category);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Category>> GetAllCategories(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = null)
        {
             return await _unitOfWork.Category.GetAll(filter, orderBy , includeProperties);

        }

        public IEnumerable<SelectListItem> GetCategoriesList()
        {
            return _unitOfWork.Category.GetCategoriesList();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _unitOfWork.Category.GetById(id);

        }

        public async Task<Category?> GetCategoryFirstOrDefault(Expression<Func<Category, bool>> filter = null, string includeProperties = null)
        {
            return await _unitOfWork.Category.GetFirstOrDefault(filter, includeProperties);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = await _unitOfWork.Category.GetById(id);
            if (categoryEntity != null)
            {
                _unitOfWork.Category.Remove(categoryEntity);
                await _unitOfWork.Save();
            }
        }

        public void RemoveCategory(Category category)
        {
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
        }

        public async Task UpdateCategory(Category category)
        {
            await _unitOfWork.Category.Update(category);
            await _unitOfWork.Save();
        }
    }
}
