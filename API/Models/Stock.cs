namespace Shop.API.Models
{

    public class Stock
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public long amount { get; set; }
        public bool isAvailable
        {
            get { return amount > 0 ? true : false; }
        }

        public virtual Product Product { get; set; }
    }

}