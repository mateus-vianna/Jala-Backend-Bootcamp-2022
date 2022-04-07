using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Shop.API.Repository;
using Shop.API.Models;

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

        [HttpGet("/api/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



    }

}