using Microsoft.AspNetCore.Mvc;
using ProductManagement.BLL.DTOs;
using ProductManagement.BLL.Interfaces;
using ProductManagement.WebApi.RabbitMQ;

namespace ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public ProductsController(ILogger<ProductsController> logger, IProductService productService, ICategoryService categoryService, ISubCategoryService subCategoryService, IRabbitMQProducer rabbitMQProducer)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                if (products == null)
                {
                    return NotFound("Not any products found!");
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        //[HttpGet("/filter")]
        //public async Task<IActionResult> GetByFilter([FromQuery] ProductDTO productDTO)
        //{
        //    try
        //    {

        //        //var products = _productService.GetAllProductsByFilterAsync(expression);
        //        //if (products == null)
        //        //{
        //        //    return NotFound("Not any products found!");
        //        //}
        //        //return Ok(products);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.ToString());
        //        return StatusCode(500, e);
        //    }
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if(product == null)
                {
                    return NotFound($"Product with id: {id} not found!");
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO toBeCreatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _categoryService.IsValidCategoryID(toBeCreatedProduct.CategoryID))
            {
                return NotFound($"Category ID: {toBeCreatedProduct.CategoryID} not found in categories!");
            }

            if (!await _subCategoryService.IsValidSubCategoryID(toBeCreatedProduct.SubCategoryID))
            {
                return NotFound($"SubCategory ID: {toBeCreatedProduct.SubCategoryID} not found in subcategories!");
            }

            try
            {
                var createdProduct = await _productService.CreateProductAsync(toBeCreatedProduct);
                _rabbitMQProducer.SendProductCreatedMessage(createdProduct);
                return CreatedAtAction(nameof(GetById), new { id = createdProduct.ID }, createdProduct);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDTO toBeUpdatedProduct)
        {
            if (id != toBeUpdatedProduct.ID)
            {
                return BadRequest("ids doesn't match!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _categoryService.IsValidCategoryID(toBeUpdatedProduct.CategoryID))
            {
                return NotFound($"Category ID: {toBeUpdatedProduct.CategoryID} not found in categories!");
            }

            if (!await _subCategoryService.IsValidSubCategoryID(toBeUpdatedProduct.SubCategoryID))
            {
                return NotFound($"SubCategory ID: {toBeUpdatedProduct.SubCategoryID} not found in subcategories!");
            }

            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(toBeUpdatedProduct);
                _rabbitMQProducer.SendProductUpdatedMessage(updatedProduct);
                return Ok(updatedProduct);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var toBeDeletedProduct = await _productService.GetProductByIdAsync(id);
                if (toBeDeletedProduct == null)
                {
                    return NotFound($"Product with id: {id} could not found!");
                }
                var deletedProduct = await _productService.DeleteProductAsync(toBeDeletedProduct);
                _rabbitMQProducer.SendProductDeletedMessage(deletedProduct);
                return Ok(deletedProduct);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }


    }
}
