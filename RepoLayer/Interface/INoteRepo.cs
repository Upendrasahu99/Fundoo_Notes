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
        public NoteEntity UpdateNote(UpdateNoteModel updateNoteModel, long userId, long noteId);
        public NoteEntity DeleteNote(long noteId, long userId);
        public NoteEntity ChangeArchive(long noteId, long userId);
        public NoteEntity ChangePinNote(long noteId, long userId);
        public NoteEntity ChangeTrashSection(long noteId, long userId);
    }
}
