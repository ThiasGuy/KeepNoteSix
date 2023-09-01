using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UserService.Entities;
using UserService.Exception;
using UserService.Services;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                var obj = _service.RegisterUser(user);
                return Created("Get/", obj);
            }
            catch (UserNotCreatedException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] User value)
        {
            try
            {
                _service.UpdateUser(id, value);
                return Ok(value);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex?.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = _service.DeleteUser(id);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = _service.GetUserById(id);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex?.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_service.GetUser());
        }
    }
}
