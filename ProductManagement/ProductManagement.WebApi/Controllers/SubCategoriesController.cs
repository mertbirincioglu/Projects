using Microsoft.AspNetCore.Mvc;
using ProductManagement.BLL.Services;
using ProductManagement.BLL.DTOs;

namespace ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGenericService<SubCategoryDTO> _subCategoryService;
        public SubCategoriesController(ILogger<SubCategoriesController> logger, IGenericService<SubCategoryDTO> subCategoryService)
        {
            _logger = logger;
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var subCategories = await _subCategoryService.GetAllAsync();
                if (subCategories == null)
                {
                    return NotFound("Not any subCategories found!");
                }
                return Ok(subCategories);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        //[HttpGet("/filter")]
        //public async Task<IActionResult> GetByFilter([FromQuery] SubCategoryDTO categoryDTO)
        //{
        //    try
        //    {

        //        //var subCategories = _productService.GetByFilterAsync(expression);
        //        //if (subCategories == null)
        //        //{
        //        //    return NotFound("Not any subCategories found!");
        //        //}
        //        //return Ok(subCategories);
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
                var subCategory = await _subCategoryService.GetByIdAsync(id);
                if (subCategory == null)
                {
                    return NotFound($"SubCategory with id: {id} not found!");
                }
                return Ok(subCategory);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubCategoryDTO toBeCreatedSubCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdSubCategory = await _subCategoryService.CreateAsync(toBeCreatedSubCategory);
                return CreatedAtAction(nameof(GetById), new { id = createdSubCategory.ID }, createdSubCategory);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubCategoryDTO toBeUpdatedSubCategory)
        {
            if (id != toBeUpdatedSubCategory.ID)
            {
                return BadRequest("ids doesn't match!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedSubCategory = await _subCategoryService.UpdateAsync(toBeUpdatedSubCategory);
                return Ok(updatedSubCategory);
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
                var toBeDeletedSubCategory = await _subCategoryService.GetByIdAsync(id);
                if (toBeDeletedSubCategory == null)
                {
                    return NotFound($"SubCategory with id: {id} could not found!");
                }
                var deletedSubCategory = await _subCategoryService.DeleteAsync(toBeDeletedSubCategory);
                return Ok(deletedSubCategory);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }
    }
     
}
