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

        [HttpGet("{id}")]
        [Route("get")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return new ObjectResult(category) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            var addedCategory = await _categoryService.AddCategory(category);
            return new ObjectResult(addedCategory) { StatusCode = StatusCodes.Status200OK };
        }

    }
}
