using Microsoft.AspNetCore.Mvc;
using SuperMarket.Entities;

namespace SuperMarket.Interfaces
{
    public interface IProductService<T> where T : ProductEntity
    {
       
        //IEnumerable<T> GetAllProducts();
        //void AddProduct(ProductEntity product);

        IEnumerable<T> GetAllProducts();
        T GetProductsById(Guid id);

        T GetProductsByIdOnly(Guid id);
        Task<T> GetProductByName(string Name);
        T AddProducts(T category);
        void UpdateProducts(T category); 
        void DeleteProducts(T category);
        IEnumerable<T> GetProductsByCategoryName(string categoryName);
        IDictionary<string, int> GetProductCountByCategory();

        Task<List<ProductEntity>> GetProductsByStockIdAsync(Guid stockId);

        Task<List<ProductEntity>> GetProductsByStockNameAsync(string stockName);

        Task SubscribeProductToCategory(string categoryName, T product);

        Task AddNewProductToExistingStockByStockId( Guid stockId, T product);
        Task AddNewProductToExistingStockByStockName( string stockName, T product);
        
        Task AddNewProductWithExistCategoryAndStockAsync(T product, string? categoryName = null, string? stockName = null);




    }
}
