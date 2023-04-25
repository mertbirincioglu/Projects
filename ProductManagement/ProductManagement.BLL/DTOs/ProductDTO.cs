using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.BLL.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string? Description { get; set; }
        [Required]
        public  int CategoryID { get; set; }
        [Required]
        public int SubCategoryID { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsAvailable { get; set; }

    }
}
