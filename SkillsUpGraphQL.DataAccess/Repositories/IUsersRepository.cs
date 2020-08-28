using SkillsUpGraphQL.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsUpGraphQL.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
    }
}
