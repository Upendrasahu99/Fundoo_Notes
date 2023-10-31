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
    }
}
