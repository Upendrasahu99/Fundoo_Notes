using BusinessLayer.Interface;
using CommonLayer.Model;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotesProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness noteBusiness;

        public NoteController(INoteBusiness noteBusiness)
        {
            this.noteBusiness = noteBusiness;
        }

        [Authorize]
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateNote(CreateNoteModel model)
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserId").Value);
                var result = noteBusiness.CreateNote(userId, model);
                if (result != null)
                {
                    return Ok(new { success = true, Message = "Note Created", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Note Note Created" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //Update Notes
        [Authorize]
        [HttpPut]
        [Route("Update/{noteId}")]

        public IActionResult UpdateNote(UpdateNoteModel updateNoteModel, long noteId)
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserId").Value);
                var result = noteBusiness.UpdateNote(updateNoteModel, userId, noteId);
                if (result != null)
                {
                    return Ok(new { success = true, Message = "Note Updated", result = result });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Note Not Updated" });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        //Get All Notes
        [Authorize]
        [HttpGet]
        [Route("Get")]
        public IActionResult GetAllNotes()
        {
            try
            {
                long userId = long.Parse(User.FindFirst("userId").Value);
                var result = noteBusiness.GetAll(userId);
                if (result != null)
                {
                    return Ok(new { success = true, Message = "All Notes List", result = result });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "There is no Notes  " });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        //Delete Note
        [Authorize]
        [HttpDelete]
        [Route("Delete/{noteId}")]
        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                long userId = long.Parse(User.FindFirst("userId").Value);
                var result = noteBusiness.DeleteNote(noteId, userId);
                if (result != null)
                {
                    return Ok(new { success = true, Message = "Note Deleted", result = result });
                }
                else
                {
                    return BadRequest(new { success = false, Message = "Don't have note" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
