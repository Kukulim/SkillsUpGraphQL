using SkillsUpGraphQL.DataBase;
using SkillsUpGraphQL.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsUpGraphQL.DataAccess.Repositories
{
    public interface ITrainersRepository
    {
        IEnumerable<Trainer> GetAll();
    }
}
