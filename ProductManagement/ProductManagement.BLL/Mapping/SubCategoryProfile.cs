using AutoMapper;
using ProductManagement.DAL.Entities;
using ProductManagement.BLL.DTOs;

namespace ProductManagement.BLL.DTOs
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryDTO, SubCategory>().ReverseMap();
        }
    }
}
