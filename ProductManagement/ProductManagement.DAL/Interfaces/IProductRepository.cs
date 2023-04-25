using ProductManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DAL.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IList<Product>> GetAllProductsAsync();
        Task<IList<Product>> GetAllProductsByFilterAsync(Expression<Func<Product, bool>> expression);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Product product);
    }
}
