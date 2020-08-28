using SkillsUpGraphQL.DataBase;
using SkillsUpGraphQL.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsUpGraphQL.DataAccess.Repositories
{
    public class TrainersRepository :ITrainersRepository
    {
        private readonly SkillsUpContext dbContext;

        public TrainersRepository(SkillsUpContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Trainer> GetAll()
        {
            return dbContext.Trainers;
        }
    }
}
