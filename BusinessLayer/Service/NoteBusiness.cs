using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NoteBusiness : INoteBusiness
    {
        private readonly INoteRepo noteRepo;

        public NoteBusiness(INoteRepo noteRepo)
        {
            this.noteRepo = noteRepo;
        }

        //Create Note
        public NoteEntity CreateNote(long userId, CreateNoteModel model)
        {
            try
            {
                return noteRepo.CreateNote(userId, model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Update Note
        public NoteEntity UpdateNote(UpdateNoteModel updateNoteModel, long userId, long noteId)
        {
            try
            {
                return noteRepo.UpdateNote(updateNoteModel, userId, noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Get All Note
        public List<NoteEntity> GetAll(long userId)
        {
            try
            {
                return noteRepo.GetAll(userId);
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
                return noteRepo.DeleteNote(noteId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //ChangeArchive
        public NoteEntity ChangeArchive(long noteId, long userId)
        {
            try
            {
                return noteRepo.ChangeArchive(noteId, userId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        //Change Pin
        public NoteEntity ChangePinNote(long noteId, long userId)
        {
            try
            {
                return noteRepo.ChangePinNote(noteId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Change TrashSection
        public NoteEntity ChangeTrashSection(long noteId, long userId)
        {
            try
            {
                return noteRepo.ChangeTrashSection(noteId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
