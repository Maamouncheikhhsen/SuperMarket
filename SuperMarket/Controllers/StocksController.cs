using Microsoft.AspNetCore.Mvc;
using SuperMarket.Entities;
using SuperMarket.Interfaces;

namespace SuperMarket.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : ControllerBase
    {
        private readonly IStockService<StockEntity> _stockService;

        public StockController(IStockService<StockEntity> stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            var stocks = _stockService.GetAllStocks();

            if (stocks == null || stocks.Count() == 0)
            {
                return NotFound();
            }

            return Ok(stocks);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetStockById(Guid id)
        {
            var stock = _stockService.GetStockById(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
        [HttpGet("name/{stockName}")]
        public async Task<IActionResult> GetStockByName(string stockName)
        {
            var stock = await _stockService.GetStockByName(stockName);
            if (stock == null)
            {
                return NotFound();
            }

            return Ok( stock);

        }

        [HttpPost]
        public IActionResult AddStock(StockEntity stock)
        {
            var addedStock = _stockService.AddStock(stock);

            return CreatedAtAction(nameof(GetStockById), new { id = addedStock.StockID }, addedStock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(Guid id, StockEntity stock)
        {
            if (id != stock.StockID)
            {
                return BadRequest();
            }

            await _stockService.UpdateStockAsync(stock);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            var stock = _stockService.GetStockById(id);

            if (stock == null)
            {
                return NotFound();
            }

           await _stockService.DeleteStockAsync(stock);

            return NoContent();
        }

        [HttpGet("byProductId/{productId}")]
        public async Task<ActionResult<List<StockEntity>>> GetStocksByProduct(Guid productId)
        {
            var stocks = await _stockService.GetStocksByProductIdAsync(productId);
            if (stocks.Count == 0)
            {
                return NoContent();
            }
            return Ok(stocks);
        }

        [HttpGet("byProductName/{productName}")]
        public async Task<ActionResult<List<StockEntity>>> GetStocksByProduct(string productName)
        {
            var stocks = await _stockService.GetStocksByProductNameAsync(productName);
            if (stocks.Count == 0)
            {
                return NoContent();
            }
            return Ok(stocks);
        }
    }

}
