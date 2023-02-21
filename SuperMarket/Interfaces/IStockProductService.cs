using SuperMarket.Entities;

namespace SuperMarket.Interfaces
{
    public interface IStockProductService<T> where T : StockProductEntity
    {
        Task AddProductToStockAsync(Guid stockId, Guid productId);

       // Task<T> GetStockByName(string stockName);
        Task RemoveProductFromStockAsync(Guid stockId, Guid productId);

        Task AddProductToStockAsyncByStockNameAndProductName(string stockName, string productName);

        Task RemoveProductFromStockAsyncByStockNameAndProductName(string stockName, string productName);
    }
}
