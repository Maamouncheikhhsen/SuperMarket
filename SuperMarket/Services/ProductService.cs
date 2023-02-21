using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.Entities;
using SuperMarket.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace SuperMarket.Services
{
    
        public class ProductService<T> : IProductService<T> where T : ProductEntity
        {
            private readonly SuperMarketDbContext _dbContext;
            private readonly IStockService<StockEntity> _stockService;
            private readonly ICategoryService<CategoryEntity> _categoryService;
            

            public ProductService(SuperMarketDbContext dbContext,ICategoryService<CategoryEntity> categoryService, IStockService<StockEntity> stockService)
            {
                _dbContext = dbContext;
                _stockService = stockService;
                _categoryService = categoryService;
              
                
            }

            public IEnumerable<T> GetAllProducts()
            {
                return _dbContext.Set<T>()
                                            .Include(s => s.StockProducts)
                                            .ThenInclude(sp => sp.Stock)
                                            .ToList();
            }

            public T GetProductsById(Guid id)
            {
                return _dbContext.Set<T>()
                                            .Include(s => s.StockProducts)
                                            .ThenInclude(sp => sp.Stock)
                                            .FirstOrDefault(p => p.ProductID == id);
            }

           public T GetProductsByIdOnly(Guid id)
            {
            return _dbContext.Set<T>()
                                        .Include(s => s.StockProducts)
                                        .ThenInclude(sp => sp.Stock)
                                        .FirstOrDefault(p => p.ProductID == id);
           }

        public async Task<T> GetProductByName(string Name)
        {
            return _dbContext.Set<T>()
                                    .Include(s => s.StockProducts)
                                    .ThenInclude(sp => sp.Stock)
                                    .FirstOrDefault(p => p.ProductName == Name);
        }

        public T AddProducts(T product)
            {
                _dbContext.Set<T>().Add(product);
                _dbContext.SaveChanges();
                return product;
            }

            public void UpdateProducts(T product)
            {
                _dbContext.Set<T>().Update(product);
                _dbContext.SaveChanges();
            }

            public void DeleteProducts(T product)
            {
                _dbContext.Set<T>().Remove(product);
                _dbContext.SaveChanges();
            }

            public IEnumerable<T> GetProductsByCategoryName(string categoryName)
            {
                return _dbContext.Set<T>().Where(p => p.Category.CategoryName == categoryName).ToList();
            }

        public IDictionary<string, int> GetProductCountByCategory()
        {
            return _dbContext.Products
                .GroupBy(p => p.Category != null ? p.Category.CategoryName : "Uncategorized")
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public async Task<List<ProductEntity>> GetProductsByStockIdAsync(Guid stockId)
        {
            var products = await _dbContext.StockProducts
                .Include(sp => sp.Product)
                .Where(sp => sp.StockID == stockId)
                .Select(sp => sp.Product)
                .ToListAsync();

            return products;

        }

        public async Task<List<ProductEntity>> GetProductsByStockNameAsync(string stockName)
        {
           // var stock = await _stockService.GetStockByName(stockName);
            var products = await _dbContext.StockProducts
             .Where(p => p.Stock.StockName == stockName)
             .Select(sp => sp.Product)
             .ToListAsync();

            return products;

        }

        public async Task AddNewProductToExistingStockByStockId(  Guid stockId, T product)
        {
            var stock = await _stockService.GetStockById(stockId);

            if (stock == null)
            {
                throw new ArgumentException($"Stock '{stockId}' does not exist");
            }

            var stockProduct = new StockProductEntity
            {
                Stock = stock,
                Product = product
            };

            stock.StockProducts.Add(stockProduct);

            AddProducts(product);

            await _stockService.UpdateStockAsync(stock);
        }
       public  async Task AddNewProductToExistingStockByStockName(string stockName, T product)
        {
            var stock = await _stockService.GetStockByName(stockName);

            if (stock == null)
            {
               
                throw new ApplicationException($"Stock  '{stockName}' does not exist");
            }

            var stockProduct = new StockProductEntity
            {
                Stock = stock,
                Product = product
            };

            if (stock.StockProducts != null)
            {
                stock.StockProducts.Add(stockProduct);

                AddProducts(product);
            }
            else
            {
                throw new ApplicationException($"Stock  '{stock.StockProducts}' does not exist");
            }
            await _stockService.UpdateStockAsync(stock);
        }

        public async Task SubscribeProductToCategory(string categoryName, T product)
        {
            var category = await _dbContext.Set<CategoryEntity>().FirstOrDefaultAsync(c => c.CategoryName == categoryName);

            if (category == null)
            {
                throw new ApplicationException($"Category '{categoryName}' does not exist");
            }

            product.Category = category;

            _dbContext.Set<ProductEntity>().Add(product);
            await _dbContext.SaveChangesAsync();
        }         

        public async Task AddNewProductWithExistCategoryAndStockAsync(T product, string? categoryName = null, string? stockName = null)
        {

            if (product == null)
            {

                throw new ApplicationException("Product object is null");
            }


            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                var category = await _categoryService.GetCategoryByName(categoryName);
                if (category == null)
                {
                    throw new ApplicationException($"Category with name '{categoryName}' not found");
                }

                product.CategoryID = category.CategoryID;
            }

            if (!string.IsNullOrWhiteSpace(stockName))
            {
                var stock = await _stockService.GetStockByName(stockName);
                if (stock == null)
                {
                    throw new ApplicationException($"Stock with name '{stockName}' not found");
                }

                await AddNewProductToExistingStockByStockName(stockName, product);
            }
            else
            { 
               await _dbContext.Products.AddAsync(product);
            }
            await _dbContext.SaveChangesAsync();

            
        }

    }


}
