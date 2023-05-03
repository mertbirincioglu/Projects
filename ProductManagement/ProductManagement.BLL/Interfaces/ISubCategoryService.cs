using ProductManagement.BLL.DTOs;

namespace ProductManagement.BLL.Interfaces
{
    public interface ISubCategoryService
    {
        Task<IList<SubCategoryDTO>> GetAllSubCategoriesAsync();
        Task<SubCategoryDTO> GetSubCategoryByIdAsync(int id);
        // Task<IList<SubCategoryDTO>> GetAllCategoriesByFilterAsync(Expression<Func<SubCategoryDTO, bool>> expression);
        Task<SubCategoryDTO> CreateSubCategoryAsync(SubCategoryDTO dto);
        Task<SubCategoryDTO> UpdateSubCategoryAsync(SubCategoryDTO dto);
        Task<SubCategoryDTO> DeleteSubCategoryAsync(SubCategoryDTO dto);
        Task<bool> IsValidSubCategoryID(int id);
    }
}
