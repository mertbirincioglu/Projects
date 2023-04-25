using ProductManagement.BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.BLL.DTOs
{
    public class SubCategoryDTO : BaseDTO
    {
        public string? Description { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
