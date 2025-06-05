using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ShelfSync.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("get")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Category cannot be null");
                }

                var addedCategory = await _categoryService.AddCategory(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = addedCategory.Id }, addedCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
