using SuperMarket.Services;
using SuperMarket.Entities;

namespace SuperMarket.Interfaces
{
    public interface ICategoryService<T> where T : CategoryEntity
    {
 
        IEnumerable<T> GetAllCategories();
        T GetCategoryById(Guid id);
        // T GetCategoryByName(string categoryName);

       T GetCategoryByCategoryName(string categoryName);
        
       Task<T> GetCategoryByName(string categoryName);
            T AddCategory(T category);
        //void UpdateCategory(T category);
       // Task<T> UpdateCategoryAsync(T category);
        void DeleteCategory(T category);
        Task<T> UpdateCategoryAsync(T category);
    }
}
