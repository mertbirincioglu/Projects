using AutoMapper;
using ProductManagement.DAL.Entities;

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
