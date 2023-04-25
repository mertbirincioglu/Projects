using Microsoft.AspNetCore.Mvc;
using ProductManagement.BLL.Services;
using ProductManagement.BLL.DTOs;

namespace ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGenericService<ProductDTO> _productService;
        public ProductsController(ILogger<ProductsController> logger, IGenericService<ProductDTO> productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllAsync();
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
                var product = await _productService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create([FromBody] ProductDTO toBeCreatedproduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var createdProduct = await _productService.CreateAsync(toBeCreatedproduct);
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

            try
            {
                var updatedProduct = await _productService.UpdateAsync(toBeUpdatedProduct);
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
                var toBeDeletedProduct = await _productService.GetByIdAsync(id);
                if (toBeDeletedProduct == null)
                {
                    return NotFound($"Product with id: {id} could not found!");
                }
                var deletedProduct = await _productService.DeleteAsync(toBeDeletedProduct);
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
