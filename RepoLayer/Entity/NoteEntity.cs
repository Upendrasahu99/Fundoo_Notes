﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RepoLayer.Entity
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime EditedTime { get; set; }
        public DateTime? Reminder { get; set; }
        public string BackgroundColor { get; set; }
        public string ImagePath { get; set; }
        public bool Archive { get; set; }
        public bool PinNote { get; set; }
        public bool Trash { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        [JsonIgnore]
        public UserEntity User { get; set; }
    }
}
