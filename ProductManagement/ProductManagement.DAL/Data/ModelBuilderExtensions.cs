using Microsoft.EntityFrameworkCore; 
using ProductManagement.DAL.Entities;

namespace ProductManagement.DAL.Data
{
    internal static class ModelBuilderExtensions
    {
        internal static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Food", Description = "Edible"}
               
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { ID = 1, Name = "Fruit", Description = "Apple, Orange etc.", CategoryID = 1},
                new SubCategory { ID = 2, Name = "Vegetable", Description = "Broccoli , Cabbage etc.", CategoryID = 1 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Name = "Apple", Price = 9.90M , Stock = 7, IsAvailable = true, CategoryID = 1, SubCategoryID = 1},
                new Product { ID = 2, Name = "Broccoli", Price = 5.90M, Stock = 4, IsAvailable = true, CategoryID = 1, SubCategoryID = 2 }
            );
        }
    }
}
