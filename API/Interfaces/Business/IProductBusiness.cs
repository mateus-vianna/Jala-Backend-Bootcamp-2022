
using Shop.API.Models;

public interface IProductBusiness
{
    IEnumerable<Product> GetAll();

    Task<Product> GetById(int id);

    Task<Product> CreateProduct(Product product);

    Task<Product> DeleteById(int id);
    Task<Product> UpdateProduct(Product product);

}
