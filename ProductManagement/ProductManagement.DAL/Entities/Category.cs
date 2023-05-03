using System.Text.Json.Serialization;


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
