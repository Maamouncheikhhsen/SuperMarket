using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.Entities;
using SuperMarket.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace SuperMarket.Services
{
    public class StockService<T> : IStockService<T> where T : StockEntity
    {
        private readonly SuperMarketDbContext _dbContext;

        public StockService(SuperMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAllStocks()
        {
            return _dbContext.Set<T>()
                                        .Include(s => s.StockProducts)
                                        .ThenInclude(sp => sp.Product)
                                        .ToList();
                //.Include(s => s.StockProducts).ThenInclude(sp => sp.Product);
        }

        //public T GetStockById(Guid id)
        //{
        //    return _dbContext.Set<T>()
        //                               //.Include(s => s.StockProducts).ThenInclude(sp => sp.Product)
        //                               .FirstOrDefault(s => s.StockID == id);
        //}
        public  async Task<T> GetStockById(Guid id)
        {
            return _dbContext.Set<T>()
                                       .Include(s => s.StockProducts)
                                       .ThenInclude(sp => sp.Product)
                                       .FirstOrDefault(s => s.StockID == id);
        }

        //public async Task<T> GetStockByStockName(string stockName)
        //{
        //    return await _dbContext.Set<T>()
        //                   .FirstOrDefaultAsync(s => s.StockName == stockName);
        //}
        public async Task<T> GetStockByName(string stockName)
        {
            return await _dbContext.Set<T>()
                                                .Include(s => s.StockProducts)
                                                .ThenInclude(sp => sp.Product)
                                                .FirstOrDefaultAsync(s => s.StockName == stockName);
        }


        public T AddStock(T stock)
        {
            _dbContext.Set<T>().Add(stock);
            _dbContext.SaveChanges();
            return stock;
        }

        //public void UpdateStock(T stock)
        //{
        //    _dbContext.Entry(stock).State = EntityState.Modified;
        //    _dbContext.SaveChanges();
        //}

        public async Task UpdateStockAsync(T stock)
        {
           _dbContext.Entry(stock).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteStockAsync(Task<T> stock)
        {
           _dbContext.Set<T>().Remove(await stock);
            _dbContext.SaveChanges();
        }

        public async Task<List<StockEntity>> GetStocksByProductIdAsync(Guid productId)
        {
            var stocks = await _dbContext.StockProducts
                .Include(sp => sp.Stock)
                .Where(sp => sp.ProductID == productId)
                .Select(sp => sp.Stock)
                .ToListAsync();

            return stocks;
        }


        public async Task<List<StockEntity>> GetStocksByProductNameAsync(string productName)
        {
            var stocks = await _dbContext.StockProducts
                .Include(sp => sp.Stock)
                .Where(sp => sp.Product.ProductName== productName)
                .Select(sp => sp.Stock)
                .ToListAsync();

            return stocks;
        }

    }

}
