using GraphQL;
using Microsoft.Extensions.DependencyInjection;
using SkillsUpGraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsUpGraphQL.Schema
{
    public class SkillUpSchema : GraphQL.Types.Schema
    {
        public SkillUpSchema(IServiceProvider provider)
        {
            Query = provider.GetRequiredService<TrainerQuery>();
        }
    }
}
