using AutoMapper;
using ProductManagement.DAL.Entities;

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
