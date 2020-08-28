using GraphQL.Types;
using SkillsUpGraphQL.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SkillsUpGraphQL.Types
{
    public class TrainerType: ObjectGraphType<Trainer>
    {
        public TrainerType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.City);
        }
    }
}
