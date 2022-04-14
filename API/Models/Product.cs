using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shop.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Sku { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int StockId { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }
        [JsonIgnore]
        public virtual Stock? Stock { get; set; }


    }
}