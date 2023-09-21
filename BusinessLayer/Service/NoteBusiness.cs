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
    }
}
