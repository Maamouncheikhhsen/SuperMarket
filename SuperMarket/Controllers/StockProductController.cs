using Microsoft.AspNetCore.Mvc;
using SuperMarket.Entities;
using SuperMarket.Interfaces;
using SuperMarket.Services;

namespace SuperMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockProductController : ControllerBase
    {
        private readonly IStockProductService<StockProductEntity> _stockProductService;
        private readonly IStockService<StockEntity> _stockService;
        private readonly IProductService<ProductEntity> _productService;

        public StockProductController(IStockProductService<StockProductEntity> stockProductService, IStockService<StockEntity> stockService, IProductService<ProductEntity> productService)
        {
            _stockProductService = stockProductService;
            _stockService = stockService;
            _productService = productService;
        }


        [HttpPost("addProductToStock")]
        public async Task<IActionResult> AddProductToStock(Guid stockId, Guid productId)
        {
            await _stockProductService.AddProductToStockAsync(stockId, productId);
            return Ok();
        }

        [HttpPost("removeProductFromStock")]
        public async Task<IActionResult> RemoveProductFromStock(Guid stockId, Guid productId)
        {
            await _stockProductService.RemoveProductFromStockAsync(stockId, productId);
            return Ok();
        }

        [HttpPost("addProductToStockByStockNameAndProductName")]
        public async Task<IActionResult> AddProductToStockByStockNameAndProductName(string stockName, string productName)
        {
            await _stockProductService.AddProductToStockAsyncByStockNameAndProductName(stockName, productName);
            return Ok();
        }

        [HttpPost("removeProductFromStockByStockNameAndProductName")]
        public async Task<IActionResult> RemoveProductFromStockByStockNameAndProductName(string stockName, string productName)
        {
            await _stockProductService.RemoveProductFromStockAsyncByStockNameAndProductName(stockName, productName);
            return Ok();
        }
    }

}
