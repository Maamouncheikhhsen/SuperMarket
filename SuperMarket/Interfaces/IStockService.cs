using SuperMarket.Entities;

namespace SuperMarket.Interfaces
{
    public interface IStockService<T> where T : StockEntity
    {
        IEnumerable<T> GetAllStocks();
        // T GetStockById(Guid id);
        Task<T> GetStockById(Guid id);
        Task<T> GetStockByName(string stockEntity);
        T AddStock(T stock);
        // void UpdateStock(T stock);

        Task UpdateStockAsync(T stock);
        //  void DeleteStock(T stock);
         Task DeleteStockAsync(Task<T> stock);
        Task<List<StockEntity>> GetStocksByProductIdAsync(Guid productId);
        Task<List<StockEntity>> GetStocksByProductNameAsync(string productName);





    }
}
