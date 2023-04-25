using ProductManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DAL.Interfaces
{
    public  interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        Task<IList<SubCategory>> GetAllSubCategoriesAsync();
        Task<IList<SubCategory>> GetAllSubCategoriesByFilterAsync(Expression<Func<SubCategory, bool>> expression);
        Task<SubCategory> GetSubCategoryByIdAsync(int id);
        Task<SubCategory> CreateSubCategoryAsync(SubCategory subCategory);
        Task<SubCategory> UpdateSubCategoryAsync(SubCategory subCategory);
        Task<SubCategory> DeleteSubCategoryAsync(SubCategory subCategory);
    }
}
