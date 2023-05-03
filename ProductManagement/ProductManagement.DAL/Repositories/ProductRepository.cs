using Microsoft.EntityFrameworkCore;
using ProductManagement.DAL.Data;
using ProductManagement.DAL.Entities;
using ProductManagement.DAL.Interfaces;
using System.Linq.Expressions;

namespace ProductManagement.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementDbContext context) : base(context)
        {

        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            base.Create(product);
            await base._context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            base.Delete(product);
            await base._context.SaveChangesAsync();
            return product;
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            return await base.FindAll().ToListAsync();
        }

        public async Task<IList<Product>> GetAllProductsByFilterAsync(Expression<Func<Product, bool>> expression)
        {
            return await base.FindByCondition(expression).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await base.FindByCondition(p => p.ID == id).FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            base.Update(product);
            await base._context.SaveChangesAsync();
            return product;
        }
    }
}
