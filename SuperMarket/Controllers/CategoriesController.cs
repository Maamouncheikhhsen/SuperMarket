using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Entities;
using SuperMarket.Interfaces;

namespace SuperMarket.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService<CategoryEntity> _categoryService;

        public CategoriesController(ICategoryService<CategoryEntity> categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("id/{id}", Name = "GetCategoryByID")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("CategoryName/{categoryname}", Name = "GetCategoryByCategroyName")]
        public IActionResult GetCategoryByCatName(string Categoryname)
        {
            var category = _categoryService.GetCategoryByCategoryName(Categoryname);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        //[HttpGet("name/{name}", Name = "GetCategoryByName")]
        //public IActionResult GetCategoryByName(string name)
        //{
        //    var category = _categoryService.GetCategoryByName(name);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(category);
        //}

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryEntity category)
        {
            if (category == null)
            {
                return BadRequest("Category object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            category.CategoryID = Guid.NewGuid();
            _categoryService.AddCategory(category);

            return CreatedAtRoute("GetCategoryByID", new { id = category.CategoryID }, category);
        }



        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateCategory(Guid id, [FromBody] CategoryEntity category)
        {
            if (category == null)
            {
                return BadRequest("Category object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.CategoryName = category.CategoryName;
            await _categoryService.UpdateCategoryAsync(existingCategory);

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(category);

            return NoContent();
        }
    }
}
    



