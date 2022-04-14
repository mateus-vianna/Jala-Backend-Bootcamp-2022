using Shop.API.Repository;
using Shop.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Shop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("/api/Products/{id}")]
        public async Task<ActionResult<Product>> GetById([FromRoute] int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return StatusCode(201, "Product create");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {

                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return StatusCode(404, "Sorry bro");
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return StatusCode(200, product);

            }
            catch (System.Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return StatusCode(400, "Not the same product");
            }

            _context.Entry(product).State = EntityState.Modified;
            // _context.Products.Update(product);

            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(202, product);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Something went wrong");
                throw;
            }
        }

    }

}