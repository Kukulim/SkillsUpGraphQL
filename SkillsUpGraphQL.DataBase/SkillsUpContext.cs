using Microsoft.EntityFrameworkCore;
using SkillsUpGraphQL.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsUpGraphQL.DataBase
{
    public class SkillsUpContext: DbContext
    {
        public SkillsUpContext(DbContextOptions<SkillsUpContext> options) : base(options)
        {

        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
