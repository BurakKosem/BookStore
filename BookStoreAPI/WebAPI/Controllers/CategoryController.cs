using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            await _categoryService.Add(categoryDto);
            return Ok("Ok");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok("Ok");
        }

        [HttpPut("update")]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(categoryDto);
            return Ok("Ok");
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }
    }
}
