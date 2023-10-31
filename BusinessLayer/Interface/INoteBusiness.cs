using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBusiness
    {
        public NoteEntity CreateNote(long userId, CreateNoteModel model);
        public List<NoteEntity> GetAll(long userId);
        public NoteEntity UpdateNote(UpdateNoteModel updateNoteModel, long userId, long noteId);
    }
}
