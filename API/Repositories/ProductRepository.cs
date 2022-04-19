using Microsoft.EntityFrameworkCore;
using Shop.API.Models;

namespace Shop.API.Repository
{

    public class ProductRepository : IProductRepository
    {
        public readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.Database.EnsureCreated();

        }


        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (System.Exception e)
            {
                throw new Exception("Product.Repository.GetAll()", e);
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                var result = await _context.Products.FindAsync(id);
                if (result == null)
                {
                    throw new Exception("Product.Repository.GetById() - Result is null");
                }
                return result;
            }
            catch (System.Exception e)
            {
                throw new Exception("Product.Repository.GetById()", e);
            }
        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var result = await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (System.Exception e)
            {
                throw new Exception("Product.Repository.CreateProduct()", e);
            }
        }

        public async Task<Product> DeleteById(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }

                var result = _context.Products.Remove(product).Entity;
                await _context.SaveChangesAsync();
                return result;
            }
            catch (System.Exception e)
            {

                throw new Exception("Product.Repository.DeleteById()", e);
            }

        }



        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                var result = _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (System.Exception e)
            {
                throw new Exception("Product.Repository.UpdatePRoduct()", e);
            }
        }


    }



}