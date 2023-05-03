using AutoMapper;
using ProductManagement.BLL.DTOs;
using ProductManagement.DAL.Interfaces;
using ProductManagement.DAL.Entities;
using ProductManagement.BLL.Interfaces;

namespace ProductManagement.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private  readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO toBeCreatedCategory)
        {
            var createdCategory = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.CreateCategoryAsync(_mapper.Map<CategoryDTO, Category>(toBeCreatedCategory)));
            return createdCategory;
        }

        public async Task<CategoryDTO> DeleteCategoryAsync(CategoryDTO toBeDeletedCategory)
        {
            var deletedCategory = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.DeleteCategoryAsync(_mapper.Map<CategoryDTO, Category>(toBeDeletedCategory)));
            return deletedCategory;
        }

        public async Task<IList<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = _mapper.Map<IList<Category>, IList<CategoryDTO>>(await _categoryRepository.GetAllCategoriesAsync());
            return categories;
        }

        //public async Task<IList<CategoryDTO>> GetAllByFilterAsync(Expression<Func<CategoryDTO, bool>> expression)
        //{
        //    var categories = _mapper.Map<IList<Category>, IList<CategoryDTO>>(await _categoryRepository.GetAllCategoriesByFilterAsync(expression));
        //    return categories;
        //}

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.GetCategoryByIdAsync(id));
            return category;
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO toBeUpdatedCategory)
        {
            var updatedCategory = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.UpdateCategoryAsync(_mapper.Map<CategoryDTO, Category>(toBeUpdatedCategory)));
            return updatedCategory;
        }

        public async Task<bool> IsValidCategoryID(int id)
        {
            var categories = await this.GetAllCategoriesAsync();
            return categories.Select(c => c.ID).Contains(id);
        }
    }
}
