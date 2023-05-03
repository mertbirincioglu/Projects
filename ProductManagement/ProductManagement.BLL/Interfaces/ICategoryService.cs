using ProductManagement.BLL.DTOs;

namespace ProductManagement.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IList<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        // Task<IList<CategoryDTO>> GetAllCategoriesByFilterAsync(Expression<Func<CategoryDTO, bool>> expression);
        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO dto);
        Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO dto);
        Task<CategoryDTO> DeleteCategoryAsync(CategoryDTO dto);
        Task<bool> IsValidCategoryID(int id);
    }
}
