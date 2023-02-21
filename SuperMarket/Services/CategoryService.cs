using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.Entities;
using SuperMarket.Interfaces;
using SuperMarket.Services;


namespace SuperMarket.Services
{
    public class CategoryService:ICategoryService<CategoryEntity>
    {
        protected SuperMarketDbContext _context;

        public CategoryService(SuperMarketDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryEntity> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public CategoryEntity GetCategoryById(Guid id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryID == id);
        }

        public async Task <CategoryEntity> GetCategoryByName (string categoryName)
        {
            return await _context.Set<CategoryEntity>().FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        }

        public CategoryEntity AddCategory(CategoryEntity category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            category.CategoryID = Guid.NewGuid();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        //public void UpdateCategory(CategoryEntity category)
        //{
        //    if (category == null)
        //    {
        //        throw new ArgumentNullException(nameof(category));
        //    }

        //    _context.Entry(category).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

      public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

                _context.Entry(category).State = EntityState.Modified;
              await  _context.SaveChangesAsync();
            return category;
        }


        public void DeleteCategory(CategoryEntity category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }






    }
}
