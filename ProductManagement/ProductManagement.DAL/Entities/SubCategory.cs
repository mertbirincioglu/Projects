using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProductManagement.DAL.Entities;

namespace ProductManagement.DAL.Entities
{
    public class SubCategory : BaseEntity
    {
        public string? Description { get; set; }  
        public int CategoryID { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual List<Product> Products { get; set; }

    }
}
