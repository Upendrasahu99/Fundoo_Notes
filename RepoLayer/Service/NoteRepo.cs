using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class NoteRepo : INoteRepo
    {
        private readonly FundooContext fundooContext;

        public NoteRepo(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        //Create Note
        public NoteEntity CreateNote(long userId, CreateNoteModel model)
        {
            try
            {
                NoteEntity newNote = new NoteEntity();
                newNote.Title = model.Title;
                newNote.Note = model.Note;
                newNote.EditedTime = DateTime.Now;
                newNote.Reminder = model.Reminder;
                newNote.BackgroundColor = model.BackgroundColor;
                newNote.ImagePath = model.ImagePath;
                newNote.Archive = model.Archive;
                newNote.PinNote = model.PinNote;
                newNote.UserId = userId;
                fundooContext.Add(newNote);
                fundooContext.SaveChanges();

                if (newNote != null)
                {
                    return newNote;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //UpdateNote
        public NoteEntity UpdateNote(UpdateNoteModel updateNoteModel, long userId, long noteId)
        {
            try
            {
                NoteEntity note = fundooContext.Note.FirstOrDefault(u => u.NoteId == noteId && u.UserId == userId);
                if (note != null)
                {
                    note.Title = updateNoteModel.Title;
                    note.Note = updateNoteModel.Note;
                    note.EditedTime = DateTime.Now;
                    note.BackgroundColor = updateNoteModel.BackgroundColor;
                    note.ImagePath = updateNoteModel.ImagePath;
                    note.Archive = updateNoteModel.Archive;
                    note.PinNote = updateNoteModel.PinNote;
                    note.Trash = updateNoteModel.Trash;
                    fundooContext.SaveChanges();
                    return note;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get All Note of One user
        public List<NoteEntity> GetAll(long userId)
        {
            try
            {
                var result = fundooContext.Note.Where(u => u.UserId == userId).ToList();

                if (result.Count > 0)
                {
                    return result;
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //DeleteNote
        public NoteEntity DeleteNote(long noteId, long userId)
        {
            try
            {
                NoteEntity note = fundooContext.Note.SingleOrDefault(u => u.NoteId == noteId && u.UserId == userId);
                if (note != null)
                {
                    fundooContext.Remove(note);
                    fundooContext.SaveChanges();
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Change Archive
        public NoteEntity ChangeArchive(long noteId, long userId)
        {
            try
            {
                NoteEntity note = fundooContext.Note.SingleOrDefault(u => u.NoteId == noteId && u.UserId == userId);

                if (note != null && note.Archive == true)
                {
                    note.Archive = false;
                    fundooContext.SaveChanges();
                    return note;
                }
                else if (note != null && note.Archive == false)
                {
                    note.Archive = true;
                    fundooContext.SaveChanges();
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Change PinNote
        public NoteEntity ChangePinNote(long noteId, long userId)
        {
            try
            {
                NoteEntity note = fundooContext.Note.SingleOrDefault(u => u.NoteId == noteId && u.UserId == userId);
                if (note != null && note.PinNote == true)
                {
                    note.PinNote = false;
                    fundooContext.SaveChanges();
                    return note;
                }
                else if (note != null && note.PinNote == false)
                {
                    note.PinNote = true;
                    fundooContext.SaveChanges();
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
