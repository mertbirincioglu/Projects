using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductManagement.BLL.DTOs
{
    public class BaseDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
