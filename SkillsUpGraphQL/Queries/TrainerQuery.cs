using GraphQL.Types;
using SkillsUpGraphQL.DataAccess.Repositories;
using SkillsUpGraphQL.DataBase.Models;
using SkillsUpGraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsUpGraphQL.Queries
{
    public class TrainerQuery: ObjectGraphType
    {
        public TrainerQuery(ITrainersRepository trainersRepository)
        {
            Field<ListGraphType<TrainerType>>(
                "trainers",
                resolve: context => trainersRepository.GetAll());
        }
    }
}
