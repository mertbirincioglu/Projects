using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DAL.Entities;

namespace ProductManagement.DAL.Data
{
    public class ProductManagementDbContext : DbContext
    {
        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : base(options)
        {
            //
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //In memory database
            //optionsBuilder.UseInMemoryDatabase("ProductManagement");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<Product>().HasOne(p => p.SubCategory).WithMany(sc => sc.Products).HasForeignKey(p => p.SubCategoryID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<SubCategory>().HasOne(sc => sc.Category).WithMany(c => c.SubCategories).HasForeignKey(sc => sc.CategoryID).OnDelete(DeleteBehavior.NoAction); ;

            modelBuilder.Seed();
        }

        internal virtual DbSet<Product> Products { get; set; }
        internal virtual DbSet<Category> Categories { get; set; }
        internal virtual DbSet<SubCategory> SubCategories { get; set; }

    }
}
