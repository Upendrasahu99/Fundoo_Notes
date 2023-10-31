using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface INoteRepo
    {
        public NoteEntity CreateNote(long userId, CreateNoteModel model);
        public List<NoteEntity> GetAll(long userId);
    }
}
