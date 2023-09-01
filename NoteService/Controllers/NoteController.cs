using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Entities;
using NoteService.Exceptions;
using NoteService.Service;

namespace NoteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;
        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Note note)
        { 
            try
            {
                var result = noteService.CreateNote(note);
                return StatusCode(201, note);
            }
            catch (NoteAlreadyExistsException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


      
        [HttpDelete("{userId}/{noteId}")]
        public IActionResult Delete(string userId, int noteId)
        {
            try
            {
                var result = noteService.DeleteNote(userId, noteId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPut("{userId}/{noteId}")]
        public IActionResult Put(string userId, int noteId, [FromBody] Note value)
        {
            try
            {
                var result = noteService.UpdateNote(noteId, userId, value);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            try
            {
                var result = noteService.GetAllNotesByUserId(userId);
                return Ok(result);
            }
            catch (NoteNotFoundException)
            {
                return NotFound(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet("{userId}/{noteId}")]
        public IActionResult Get(string userId, int noteId)
        {
            try
            {
                var result = noteService.GetNoteByNoteId(userId, noteId);
                return Ok(result);
            }
            catch (NoteNotFoundException)
            {
                return NotFound(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
