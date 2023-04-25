using Microsoft.EntityFrameworkCore;
using ProductManagement.DAL.Data;
using ProductManagement.DAL.Entities;
using ProductManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DAL.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ProductManagementDbContext context) : base(context)
        {

        }

        public async Task<SubCategory> CreateSubCategoryAsync(SubCategory subCategory)
        {
            base.Create(subCategory);
            await base._context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> DeleteSubCategoryAsync(SubCategory subCategory)
        {
            base.Delete(subCategory);
            await base._context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<IList<SubCategory>> GetAllSubCategoriesAsync()
        {
            return await base.FindAll().ToListAsync();
        }

        public async Task<IList<SubCategory>> GetAllSubCategoriesByFilterAsync(Expression<Func<SubCategory, bool>> expression)
        {
            return await base.FindByCondition(expression).ToListAsync();
        }

        public async Task<SubCategory> GetSubCategoryByIdAsync(int id)
        {
            return await base.FindByCondition(c => c.ID == id).FirstOrDefaultAsync();
        }

        public async Task<SubCategory> UpdateSubCategoryAsync(SubCategory subCategory)
        {
            base.Update(subCategory);
            await base._context.SaveChangesAsync();
            return subCategory;
        }
    }
}

