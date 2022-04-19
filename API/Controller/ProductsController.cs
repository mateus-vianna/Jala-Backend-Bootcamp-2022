
using Shop.API.Models;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Business;

namespace Shop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        public readonly IProductBusiness _productBusiness;
        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {

            try
            {
                var result = _productBusiness.GetAll();
                if (result == null || !result.Any())
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (System.Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong");
            }

        }

        [HttpGet("/api/Products/{id}")]
        public async Task<ActionResult<Product>> GetById([FromRoute] int id)
        {
            try
            {
                var result = await _productBusiness.GetById(id);
                return Ok(result);
            }
            catch (System.Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong");
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                var result = await _productBusiness.CreateProduct(product);
                return StatusCode(201, result);
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
                return StatusCode(200, await _productBusiness.DeleteById(id));

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
            try
            {
                return StatusCode(201, await _productBusiness.UpdateProduct(product));
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong");
            }
        }

    }

}