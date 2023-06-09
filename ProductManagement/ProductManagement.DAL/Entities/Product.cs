﻿using System.Text.Json.Serialization;

namespace ProductManagement.DAL.Entities
{
    public class Product: BaseEntity
    {
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }  
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsAvailable { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual SubCategory SubCategory { get; set; }  
    }
}
