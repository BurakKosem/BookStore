using Business.Abstract;
using Business.ActionFilters;
using Business.Validations;
using Core.Exceptions;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "User")]
    [ApiVersion("1.0")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize(Roles = "User, Admin")]
        [HttpHead]
        [HttpGet("getall")]
        
        public async Task<IActionResult> GetAll()
        {
            var result = _bookService.GetAll(false);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bookService.GetById(id, false);
            return Ok(result.Name);
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _bookService.GetByName(name, false);
            return Ok(result);
        }

        [HttpGet("getbycategoryid")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var result = _bookService.GetByCategory(id, false);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> Add(BookDto bookDto)
        {
            await _bookService.Add(bookDto);
            return Ok("Book added successfully");           
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
           var result = await _bookService.Delete(id);
           return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(BookDto bookDto)
        {
            _bookService.Update(bookDto);           
            return Ok("Book updated succesfully");
        }

        [HttpOptions]
        public IActionResult GetBookOptions() 
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}
