using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Sku { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int StockId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Stock? Stock { get; set; }


    }
}