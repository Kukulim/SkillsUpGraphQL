using GraphQL;
using SkillsUpGraphQL.Queries;

namespace SkillsUpGraphQL.Schema
{
    public class SkillUpSchema : GraphQL.Types.Schema
    {
        public SkillUpSchema(IDependencyResolver resolver) :
       base(resolver)
    {
            Query = resolver.Resolve<TrainerQuery>();
        }
    }
}

