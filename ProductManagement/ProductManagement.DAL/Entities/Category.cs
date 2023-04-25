using ProductManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductManagement.DAL.Entities
{
    public class Category: BaseEntity
    {
        public string? Description { get; set; }

        [JsonIgnore]
        public virtual List<Product> Products { get; set; }

        [JsonIgnore]
        public virtual List<SubCategory> SubCategories { get; set; }    
    }
}
