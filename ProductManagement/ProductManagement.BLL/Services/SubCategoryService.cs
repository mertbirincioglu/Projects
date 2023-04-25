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
    public  class SubCategoryService : IGenericService<SubCategoryDTO>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<SubCategoryDTO> CreateAsync(SubCategoryDTO toBeCreatedSubCategory)
        {
            var createdSubCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.CreateSubCategoryAsync(_mapper.Map<SubCategoryDTO, SubCategory>(toBeCreatedSubCategory)));
            return createdSubCategory;
        }

        public async Task<SubCategoryDTO> DeleteAsync(SubCategoryDTO toBeDeletedSubCategory)
        {
            var deletedSubCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.DeleteSubCategoryAsync(_mapper.Map<SubCategoryDTO, SubCategory>(toBeDeletedSubCategory)));
            return deletedSubCategory;
        }

        public async Task<IList<SubCategoryDTO>> GetAllAsync()
        {
            var subCategories = _mapper.Map<IList<SubCategory>, IList<SubCategoryDTO>>(await _subCategoryRepository.GetAllSubCategoriesAsync());
            return subCategories;
        }

        //public async Task<IList<SubCategoryDTO>> GetAllByFilterAsync(Expression<Func<SubCategoryDTO, bool>> expression)
        //{
        //    var subCategories = _mapper.Map<IList<SubCategory>, IList<SubCategoryDTO>>(await _subCategoryRepository.GetAllSubCategoriesByFilterAsync(expression));
        //    return subCategories;
        //}

        public async Task<SubCategoryDTO> GetByIdAsync(int id)
        {
            var subCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.GetSubCategoryByIdAsync(id));
            return subCategory;
        }

        public async Task<SubCategoryDTO> UpdateAsync(SubCategoryDTO toBeUpdatedSubCategory)
        {
            var updatedSubCategory = _mapper.Map<SubCategory, SubCategoryDTO>(await _subCategoryRepository.UpdateSubCategoryAsync(_mapper.Map<SubCategoryDTO, SubCategory>(toBeUpdatedSubCategory)));
            return updatedSubCategory;
        }
    }
}
