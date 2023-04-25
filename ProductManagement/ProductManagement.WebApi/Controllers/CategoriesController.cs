using Microsoft.AspNetCore.Mvc;
using ProductManagement.BLL.Services;
using ProductManagement.BLL.DTOs;

namespace ProductManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGenericService<CategoryDTO> _categoryService;
        public CategoriesController(ILogger<CategoriesController> logger, IGenericService<CategoryDTO> categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                if (categories == null)
                {
                    return NotFound("Not any categories found!");
                }
                return Ok(categories);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        //[HttpGet("/filter")]
        //public async Task<IActionResult> GetByFilter([FromQuery] CategoryDTO categoryDTO)
        //{
        //    try
        //    {

        //        //var categories = _categoryService.GetAllByFilterAsync(expression);
        //        //if (categories == null)
        //        //{
        //        //    return NotFound("Not any categories found!");
        //        //}
        //        //return Ok(categories);
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
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound($"Category with id: {id} not found!");
                }
                return Ok(category);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDTO toBeCreatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdCategory = await _categoryService.CreateAsync(toBeCreatedCategory);
                return CreatedAtAction(nameof(GetById), new { id = createdCategory.ID }, createdCategory);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO toBeUpdatedCategory)
        {
            if (id != toBeUpdatedCategory.ID)
            {
                return BadRequest("ids doesn't match!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedCategory = await _categoryService.UpdateAsync(toBeUpdatedCategory);
                return Ok(updatedCategory);
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
                var toBeDeletedCategory = await _categoryService.GetByIdAsync(id);
                if (toBeDeletedCategory == null)
                {
                    return NotFound($"Category with id: {id} could not found!");
                }
                var deletedCategory = await _categoryService.DeleteAsync(toBeDeletedCategory);
                return Ok(deletedCategory);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, e);
            }
        }
    }
}
