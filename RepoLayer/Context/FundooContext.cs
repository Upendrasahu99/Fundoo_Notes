﻿using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options) :base(options) { }
        public DbSet<UserEntity> users { get; set; }
        public DbSet<NoteEntity> Note {  get; set; }
    }
}
