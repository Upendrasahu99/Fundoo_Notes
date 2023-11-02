﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RepoLayer.Entity
{
    public class CollabEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollabId { get; set; }
        public string Email { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        [JsonIgnore]
        public UserEntity User { get; set; }
        [ForeignKey("Note")]
        public long NoteId { get; set; }
        [JsonIgnore]
        public NoteEntity Note { get; set; }
    }
}
