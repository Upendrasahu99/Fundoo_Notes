﻿using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
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

    }
}