using AutoMapper;
using ProductManagement.BLL.DTOs;
using ProductManagement.DAL.Interfaces;
using ProductManagement.DAL.Entities;
using ProductManagement.BLL.Interfaces;

namespace ProductManagement.BLL.Services
{
    public  class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<SubCategoryDTO> CreateSubCategoryAsync(SubCategoryDTO toBeCreatedSubCategory)
        {
            var createdSubCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.CreateSubCategoryAsync(_mapper.Map<SubCategoryDTO, SubCategory>(toBeCreatedSubCategory)));
            return createdSubCategory;
        }

        public async Task<SubCategoryDTO> DeleteSubCategoryAsync(SubCategoryDTO toBeDeletedSubCategory)
        {
            var deletedSubCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.DeleteSubCategoryAsync(_mapper.Map<SubCategoryDTO, SubCategory>(toBeDeletedSubCategory)));
            return deletedSubCategory;
        }

        public async Task<IList<SubCategoryDTO>> GetAllSubCategoriesAsync()
        {
            var subCategories = _mapper.Map<IList<SubCategory>, IList<SubCategoryDTO>>(await _subCategoryRepository.GetAllSubCategoriesAsync());
            return subCategories;
        }

        //public async Task<IList<SubCategoryDTO>> GetAllByFilterAsync(Expression<Func<SubCategoryDTO, bool>> expression)
        //{
        //    var subCategories = _mapper.Map<IList<SubCategory>, IList<SubCategoryDTO>>(await _subCategoryRepository.GetAllSubCategoriesByFilterAsync(expression));
        //    return subCategories;
        //}

        public async Task<SubCategoryDTO> GetSubCategoryByIdAsync(int id)
        {
            var subCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.GetSubCategoryByIdAsync(id));
            return subCategory;
        }

        public async Task<SubCategoryDTO> UpdateSubCategoryAsync(SubCategoryDTO toBeUpdatedSubCategory)
        {
            var updatedSubCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.UpdateSubCategoryAsync(_mapper.Map<SubCategoryDTO, SubCategory>(toBeUpdatedSubCategory)));
            return updatedSubCategory;
        }

        public async Task<bool> IsValidSubCategoryID(int id)
        {
            var subCategories = await this.GetAllSubCategoriesAsync();
            return subCategories.Select(sc => sc.ID).Contains(id);
        }
    }
}
