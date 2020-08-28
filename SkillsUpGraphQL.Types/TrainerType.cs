using GraphQL.Types;
using SkillsUpGraphQL.DataBase.Models;

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
