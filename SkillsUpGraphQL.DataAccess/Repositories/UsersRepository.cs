using SkillsUpGraphQL.DataBase;
using SkillsUpGraphQL.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsUpGraphQL.DataAccess.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly SkillsUpContext dbContext;

        public UsersRepository(SkillsUpContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users;
        }
    }
}
