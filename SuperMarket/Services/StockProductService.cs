using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.Entities;
using SuperMarket.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace SuperMarket.Services
{
    public class StockProductService<T> : IStockProductService<T> where T : StockProductEntity
    {
        private readonly SuperMarketDbContext _dbContext;
        private readonly IStockService<StockEntity> _stockService;
        private readonly IProductService<ProductEntity> _productService;


        public StockProductService(SuperMarketDbContext dbContext, IStockService<StockEntity> stockService, IProductService<ProductEntity> productService)
        {
            _dbContext = dbContext;
            _stockService = stockService;
            _productService = productService;
        }

        public async Task AddProductToStockAsync(Guid stockId, Guid productId)
        {
            var stock = await _stockService.GetStockById(stockId);
            if (stock == null)
            {
                throw new ArgumentException($"Stock with name {stockId} not found");
            }

            var product =  _productService.GetProductsById(productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with name {productId} not found");
            }

            var stockProduct = new StockProductEntity
            {
                StockID = stockId,
                ProductID = productId
            };

            await _dbContext.StockProducts.AddAsync(stockProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveProductFromStockAsync(Guid stockId, Guid productId)
        {
            var stock = await _stockService.GetStockById(stockId);
            if (stock == null)
            {
                throw new ArgumentException($"Stock with name {stockId} not found");
            }

            var product =  _productService.GetProductsById(productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with name {productId} not found");
            }

            var stockProduct = await _dbContext.StockProducts
                .SingleOrDefaultAsync(sp => sp.StockID == stockId && sp.ProductID == productId);

            if (stockProduct != null)
            {
                _dbContext.StockProducts.Remove(stockProduct);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AddProductToStockAsyncByStockNameAndProductName(string stockName, string productName)
        {
            var stock = await _stockService.GetStockByName(stockName);
            if (stock == null)
            {
                throw new ArgumentException($"Stock with name {stockName} not found");
            }

            var product = await _productService.GetProductByName(productName);
            if (product == null)
            {
                throw new ArgumentException($"Product with name {productName} not found");
            }

            var stockProduct = new StockProductEntity
            {
                StockID = stock.StockID,
                ProductID = product.ProductID
            };

            await _dbContext.StockProducts.AddAsync(stockProduct);
            await _dbContext.SaveChangesAsync();
        }


        public async Task RemoveProductFromStockAsyncByStockNameAndProductName(string stockName, string productName)
        {
            var stock = await _stockService.GetStockByName(stockName);
            if (stock == null)
            {
                throw new ArgumentException($"Stock with name '{stockName}' not found.");
            }

            var product = await _productService.GetProductByName(productName);
            if (product == null)
            {
                throw new ArgumentException($"Product with name '{productName}' not found.");
            }

            var stockProduct = await _dbContext.StockProducts
                .FirstOrDefaultAsync(sp => sp.StockID == stock.StockID && sp.ProductID == product.ProductID);

            if (stockProduct == null)
            {
                throw new ArgumentException($"Product '{productName}' not found in stock '{stockName}'.");
            }

            _dbContext.StockProducts.Remove(stockProduct);
            await _dbContext.SaveChangesAsync();
        }

    }

}
