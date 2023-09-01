using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderService.Enitities;
using ReminderService.Exceptions;
using ReminderService.Services;

namespace ReminderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReminderController : ControllerBase
    {
        private IreminderService reminderService;

        public ReminderController(IreminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] Reminder value)
        {
            try
            {
                var result = reminderService.CreateReminder(value);
                return StatusCode(201, result);

            }
            catch (ReminderNotCreatedException)
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
                var result = reminderService.DeleteReminder(id);
                return Ok(result);
            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Reminder value)
        {
            try
            {
                var result = reminderService.UpdateReminder(id, value);
                return Ok(result);
            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("reminder/{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = reminderService.GetReminderById(id);
                return Ok(result);

            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetReminderByUserId(string userId)
        {
            try
            {
                var result = reminderService.GetAllRemindersByUserId(userId);
                return Ok(result);
            }
            catch (ReminderNotFoundException ex)
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
