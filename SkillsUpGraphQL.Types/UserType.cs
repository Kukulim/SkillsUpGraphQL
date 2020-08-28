using GraphQL.Types;
using SkillsUpGraphQL.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsUpGraphQL.Types
{
    class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
