using CategoryService.Exceptions;
using CategoryService.Models;
using CategoryService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IcategoryService service;

        public CategoryController(IcategoryService _service)
        {
            this.service = _service;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                var result = service.CreateCategory(category);
                return StatusCode(201, category);
            }
            catch (CategoryNotCreatedException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = service.DeleteCategory(id);
                return Ok(result);
            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Category value)
        {
            try
            {
                var result = service.UpdateCategory(id, value);
                return Ok(result);
            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpGet("usercategories/{userId}")]
        public IActionResult Get(string userId)
        {
            try
            {
                var result = service.GetAllCategoriesByUserId(userId);
                return Ok(result);
            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        // GET api/<controller>/5
        [HttpGet("categories/{categoryId}")]
        public IActionResult GetCategories(string categoryId)
        {
            try
            {
                var result = service.GetCategoryById(categoryId);
                return Ok(result);
            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
