using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperMarket.Data;
using SuperMarket.Entities;
using SuperMarket.Interfaces;
using SuperMarket.Services;


namespace SuperMarket.Services
{
    public class CategoryService:ICategoryService<CategoryEntity>
    {
        protected SuperMarketDbContext _context;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(SuperMarketDbContext context, ILogger<CategoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<CategoryEntity> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public CategoryEntity GetCategoryById(Guid id)
        {

            return _context.Categories
              .Include(p => p.Products)             
               .FirstOrDefault(c => c.CategoryID == id);
        }

        public CategoryEntity GetCategoryByCategoryName(string categoryName)
        {

            return _context.Categories
               .Include(p => p.Products)
                .FirstOrDefault(c => c.CategoryName == categoryName);
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
