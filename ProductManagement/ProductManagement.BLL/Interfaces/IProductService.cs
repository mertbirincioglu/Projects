using ProductManagement.BLL.DTOs;

namespace ProductManagement.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        // Task<IList<ProductDTO>> GetAllProductsByFilterAsync(Expression<Func<ProductDTO, bool>> expression);
        Task<ProductDTO> CreateProductAsync(ProductDTO dto);
        Task<ProductDTO> UpdateProductAsync(ProductDTO dto);
        Task<ProductDTO> DeleteProductAsync(ProductDTO dto);
    }
}
