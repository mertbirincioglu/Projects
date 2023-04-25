using ProductManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DAL.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IList<Category>> GetAllCategoriesAsync();
        Task<IList<Category>> GetAllCategoriesByFilterAsync(Expression<Func<Category, bool>> expression);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(Category category);
    }
}
