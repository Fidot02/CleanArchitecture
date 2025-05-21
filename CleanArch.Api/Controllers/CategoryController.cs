using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet("Get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }


        [HttpPost("Add-category")]
        public IActionResult AddCategory([FromBody] CategoryDTO categoryDTO)
        {

            _categoryService.AddCategory(categoryDTO);
            return Ok("The category was added successfully!");

        }

        [HttpGet("Get-category-by-Id/{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
         var Categorydto = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(Categorydto);
        }
    }
}
