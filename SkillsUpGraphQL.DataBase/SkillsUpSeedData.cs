using Microsoft.EntityFrameworkCore.Internal;
using SkillsUpGraphQL.DataBase.Models;
using System.Collections.Generic;

namespace SkillsUpGraphQL.DataBase
{
    public static class SkillsUpSeedData
    {
        public static void SeedData(this SkillsUpContext skillsUpContext)
        {
            if (!skillsUpContext.Trainers.Any() || !skillsUpContext.Users.Any())
            {
                var trainers = new List<Trainer>
                {
                    new Trainer
                    {
                        Name = "Lukasz",
                        City = "Grodzisko"
                    },
                    {
                    new Trainer
                    {
                        Name = "Staszek",
                        City = "Częstochowa"
                    }
                    }
                };
                var users = new List<User>
                {
                    new User
                    {
                        Name= "Gracz1"
                    },
                    new User
                    {
                        Name = "Gracz2"
                    }
                };

                skillsUpContext.Users.AddRange(users);
                skillsUpContext.Trainers.AddRange(trainers);
                skillsUpContext.SaveChanges();
          }
        }
    }
}