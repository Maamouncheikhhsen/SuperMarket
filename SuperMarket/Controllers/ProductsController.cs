using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
//using SuperMarket.Services;
using SuperMarket.Interfaces;
using SuperMarket.Services;

namespace SuperMarket.Controllers
{
   
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService<ProductEntity> _productService;
        private readonly IStockService<StockEntity> _stockService;
        private readonly ICategoryService<CategoryEntity> _categoryService;
        private readonly IStockProductService<StockProductEntity> _stockProductService;

        public ProductController(IProductService<ProductEntity> productService, IStockService<StockEntity> stockService, ICategoryService<CategoryEntity> categoryService)
        {
            _productService = productService;
            _stockService = stockService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("id/{id}")]
        public ActionResult<ProductEntity> GetProductById(Guid id)
        {
            var product = _productService.GetProductsById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpGet("name/{ProductName}")]
        public async Task<ActionResult<ProductEntity>> GetProductByName(string ProductName)
        {
            var product = await _productService.GetProductByName(ProductName);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<ProductEntity> AddProduct(ProductEntity product)
        {
            _productService.AddProducts(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);
        }

        [HttpPost("addNewProductToExistingStockByStockId")]
        public async Task<ActionResult<ProductEntity>> AddNewProductToStock(Guid stockId, ProductEntity product)
        {
            
            await _productService.AddNewProductToExistingStockByStockId(stockId, product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);
        }

        [HttpPost("addNewProductToExistingStockByStockName/stockName{stockName}")]
        public async Task<ActionResult<ProductEntity>> AddNewProductToStockByStockName(string stockName, ProductEntity product)
        {
           
            await _productService.AddNewProductToExistingStockByStockName(stockName, product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);
        }

        [HttpPost("addNewProductWithExistCategoryByCategoryId")]
        public ActionResult<ProductEntity> AddNewProduct(Guid categoryId, ProductEntity product)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                return NotFound($"Category {categoryId} not found.");
            }

            product.Category = category;

            _productService.AddProducts(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);
        }

        [HttpPost("addNewProductWithExistingCategoryByCategoryName")]
        public  async Task <ActionResult <ProductEntity>> AddNewProductWithExistCategoryByCategoryName(string categoryName, ProductEntity product)
        {
            var category =  _categoryService.GetCategoryByName(categoryName);

            if (category == null)
            {
                return NotFound($"Category {categoryName} not found.");
            }

            product.Category = await category;

            _productService.AddProducts(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);
        }

        [HttpPost("addExistingProductToExistingCategoryByProductIdAndCategoryId")]
        public  ActionResult<ProductEntity> AddExistingProductToCategory(Guid categoryid, Guid productid)
        {
            var category = _categoryService.GetCategoryById(categoryid);

            if (category == null)
            {
                throw new ApplicationException ( $"Category {categoryid} not found.");
            }

            var product =  _productService.GetProductsById(productid);

            if (product == null)
            {
                return NotFound($"Product {productid.ToString()} not found.");
            }

            category.Products.Add(product);

             _categoryService.UpdateCategoryAsync(category);

            return Ok($"Product {productid} added to category {categoryid}.");
        }

        [HttpPost("addExistingProductToExistingCategoryByNames")]
        public async Task<ActionResult<ProductEntity>> AddExistingProductToCategory(string categoryName, string productName)
        {
            var category =  await _categoryService.GetCategoryByName(categoryName);

            if (category == null)
            {
                return NotFound($"Category {categoryName} not found.");
            }

            var product = await _productService.GetProductByName(productName);

            if (product == null)
            {
                return NotFound($"Product {productName} not found.");
            }

             category.Products.Add(product);

            await _categoryService.UpdateCategoryAsync(category);

            return Ok($"Product {productName} added to category {categoryName}.");
        }


        //[HttpPost("add-new-product-with-category-and-stock/category/{categoryName?}/stock/{stockName?}")]
        //[HttpPost("add-new-product-with-category-and-stock/{categoryName?}/{stockName?}")]
        [HttpPost("add-new-product-with-category-and-stock")]
        public async Task<IActionResult> AddNewProductWithExistingCategoryAndStock([FromBody] ProductEntity product, string? categoryName = null, string? stockName = null)
        {
            //if (product == null)
            //{
            //    return BadRequest("Product object is null");
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            //if (!string.IsNullOrWhiteSpace(categoryName))
            //{
            //    var category = _categoryService.GetCategoryByName(categoryName);
            //    if (category == null)
            //    {
            //        throw new ApplicationException($"Category with name '{categoryName}' not found");
            //    }

            //    product.CategoryID = category.CategoryID;
            //}

            //if (!string.IsNullOrWhiteSpace(stockName))
            //{
            //    var stock = await _stockService.GetStockByName(stockName);
            //    if (stock == null)
            //    {
            //        throw new ApplicationException($"Stock with name '{stockName}' not found");
            //    }

            //    await AddNewProductToStockByStockName(stockName, product);
            //}
            //await _dbContext.Products.AddAsync(product);
            //await _dbContext.SaveChangesAsync();

            await _productService.AddNewProductWithExistCategoryAndStockAsync(product, categoryName, stockName);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductID }, product);



            //try
            //{
            //    await _productService.AddNewProductWithExistCategoryAndStockAsync(product, categoryName, stockName);

            //    return CreatedAtRoute(nameof(GetProductById), new { id = product.ProductID }, product);
            //}
            //catch (InvalidOperationException ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            //  return Ok();

        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, ProductEntity product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _productService.UpdateProducts(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productService.GetProductsById(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProducts(product);

            return NoContent();
        }

        [HttpGet("by-category/{categoryName}")]
        public IEnumerable<ProductEntity> GetProductsByCategoryName(string categoryName)
        {
            return _productService.GetProductsByCategoryName(categoryName);
        }

        [HttpGet("count-by-category")]
        public IActionResult GetProductCountByCategory()
        {
            var productCountByCategory = _productService.GetProductCountByCategory();
            if (productCountByCategory == null || !productCountByCategory.Any())
            {
                return NotFound();
            }
            return Ok(productCountByCategory);
        }

        [HttpGet("byStockId/{stockId}")]
        public async Task<ActionResult<List<ProductEntity>>> GetProductsByStockId(Guid stockId)
        {
            var products = await _productService.GetProductsByStockIdAsync(stockId);
            if (products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }

        [HttpGet("byStockName/{stockName}")]
        public async Task<ActionResult<List<ProductEntity>>> GetProductsByStockName(string  stockName)
        {
            var products = await _productService.GetProductsByStockNameAsync(stockName);
            if (products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
    }


}
