using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Order = 0)]
        public int ID { get; set; }

        [Required]
        [Display(Order = 1)]
        public string Name { get; set; }
    }
}
