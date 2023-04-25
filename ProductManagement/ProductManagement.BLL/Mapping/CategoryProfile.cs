using AutoMapper;
using ProductManagement.DAL.Entities;
using ProductManagement.BLL.DTOs;

namespace ProductManagement.BLL.DTOs
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
