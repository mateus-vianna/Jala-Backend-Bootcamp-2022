namespace Shop.API.Models
{
    public class Crate
    {
        public int Id { get; set; }
        public List<Product>? products { get; set; }

        public decimal total { get; set; }


    }
}