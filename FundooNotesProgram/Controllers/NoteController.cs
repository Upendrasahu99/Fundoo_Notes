﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
