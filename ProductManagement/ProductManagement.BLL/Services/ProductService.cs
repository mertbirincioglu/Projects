
using AutoMapper;
using ProductManagement.BLL.DTOs;
using ProductManagement.BLL.Interfaces;
using ProductManagement.DAL.Entities;
using ProductManagement.DAL.Interfaces;

namespace ProductManagement.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO toBeCreatedProduct)
        {
            var createdProduct = _mapper.Map<Product, ProductDTO>(await _productRepository.CreateProductAsync(_mapper.Map<ProductDTO, Product>(toBeCreatedProduct)));
            return createdProduct;
        }

        public async Task<ProductDTO> DeleteProductAsync(ProductDTO toBeDeletedProduct)
        {
            var deletedProduct = _mapper.Map<Product, ProductDTO>(await _productRepository.DeleteProductAsync(_mapper.Map<ProductDTO, Product>(toBeDeletedProduct)));
            return deletedProduct;
        }

        public async Task<IList<ProductDTO>> GetAllProductsAsync()
        {
            var products = _mapper.Map<IList<Product>, IList<ProductDTO>>(await _productRepository.GetAllProductsAsync());
            return products;
        }

        //public async Task<IList<ProductDTO>> GetAllProductsByFilterAsync(Expression<Func<ProductDTO, bool>> expression)
        //{
        //    var products = _mapper.Map<IList<Product>, IList<ProductDTO>>(await _productRepository.GetAllProductsByFilterAsync(expression));
        //    return products;
        //}

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = _mapper.Map<Product, ProductDTO>(await _productRepository.GetProductByIdAsync(id));
            return product;
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO toBeUpdatedProduct)
        {
            var updatedProduct = _mapper.Map<Product, ProductDTO>(await _productRepository.UpdateProductAsync(_mapper.Map<ProductDTO, Product>(toBeUpdatedProduct)));
            return updatedProduct;
        }
    }
}
