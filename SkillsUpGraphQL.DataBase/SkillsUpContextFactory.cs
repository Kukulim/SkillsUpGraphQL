using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SkillsUpGraphQL.DataBase
{
    public class SkillsUpContextFactory : IDesignTimeDbContextFactory<SkillsUpContext>
    {
        public SkillsUpContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SkillsUpContext>();
            var conectionString = configuration.GetConnectionString("SkillsUpDb");
            builder.UseSqlServer(conectionString);

            return new SkillsUpContext(builder.Options);
        }
    }
}
