


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Shop.API.Repository;
using Shop.API.Models;

namespace Shop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly ShopContext _context;

        public StockController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        [HttpGet]
        public ActionResult<IEnumerable<Stock>> GetAll()
        {
            return Ok(_context.Stocks.ToList());
        }

        [HttpGet("/api/Stock/{id}")]
        public async Task<ActionResult<Stock>> GetById(int id)
        {
            var result = await _context.Stocks.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> InsertIntoStock(Stock stock)
        {
            try
            {
                _context.Stocks.Add(stock);
                await _context.SaveChangesAsync();
                return StatusCode(201, "Stock saved");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost("/DeleteBatch/")]
        public async Task<ActionResult> DeleteAllStock([FromBody] List<int> ids)
        {
            try
            {
                var stocks = new List<Stock>();
                foreach (var id in ids)
                {
                    var stock = await _context.Stocks.FindAsync(id);
                    if (stock == null)
                    {
                        return StatusCode(404, "Sorry bro");
                    }
                    stocks.Add(stock);
                }

                _context.Stocks.RemoveRange(stocks);
                await _context.SaveChangesAsync();
                return StatusCode(200, "Stocks have been removed");

            }
            catch (System.Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, "Something went wrong");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStock(int id, Stock stock)
        {
            if (id != stock.Id)
            {
                return StatusCode(400, "Not the same stock");
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(202, stock);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Something went wrong");
                throw;
            }
        }

    }

}