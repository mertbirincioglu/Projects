using Microsoft.EntityFrameworkCore;
using ProductManagement.DAL.Data;
using ProductManagement.DAL.Entities;
using ProductManagement.DAL.Interfaces;
using System.Linq.Expressions;

namespace ProductManagement.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductManagementDbContext context) : base(context)
        {
      
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            base.Create(category);
            await base._context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(Category category)
        {
            base.Delete(category);
            await base._context.SaveChangesAsync();
            return category;
        }

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            return await base.FindAll().ToListAsync();
        }

        public async Task<IList<Category>> GetAllCategoriesByFilterAsync(Expression<Func<Category, bool>> expression)
        {
            return await base.FindByCondition(expression).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await base.FindByCondition(c => c.ID == id).FirstOrDefaultAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            base.Update(category);
            await base._context.SaveChangesAsync();
            return category;
        }
    }
}

