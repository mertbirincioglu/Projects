using AutoMapper;
using ProductManagement.BLL.DTOs;
using ProductManagement.DAL.Interfaces;
using ProductManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.DAL.Repositories;
using System.Linq.Expressions;

namespace ProductManagement.BLL.Services
{
    public class CategoryService : IGenericService<CategoryDTO> 
    {
        private  readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO toBeCreatedCategory)
        {
            var createdCategory = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.CreateCategoryAsync(_mapper.Map<CategoryDTO, Category>(toBeCreatedCategory)));
            return createdCategory;
        }

        public async Task<CategoryDTO> DeleteAsync(CategoryDTO toBeDeletedCategory)
        {
            var deletedCategory = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.DeleteCategoryAsync(_mapper.Map<CategoryDTO, Category>(toBeDeletedCategory)));
            return deletedCategory;
        }

        public async Task<IList<CategoryDTO>> GetAllAsync()
        {
            var categories = _mapper.Map<IList<Category>, IList<CategoryDTO>>(await _categoryRepository.GetAllCategoriesAsync());
            return categories;
        }

        //public async Task<IList<CategoryDTO>> GetAllByFilterAsync(Expression<Func<CategoryDTO, bool>> expression)
        //{
        //    var categories = _mapper.Map<IList<Category>, IList<CategoryDTO>>(await _categoryRepository.GetAllCategoriesByFilterAsync(expression));
        //    return categories;
        //}

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.GetCategoryByIdAsync(id));
            return category;
        }

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO toBeUpdatedCategory)
        {
            var updatedCategory = _mapper.Map<Category, CategoryDTO>(await _categoryRepository.UpdateCategoryAsync(_mapper.Map<CategoryDTO, Category>(toBeUpdatedCategory)));
            return updatedCategory;
        }
    }
}
