using AutoMapper;
using ProductManagement.BLL.DTOs;
using ProductManagement.DAL.Entities;

namespace ProductManagement.BLL.DTOs
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
