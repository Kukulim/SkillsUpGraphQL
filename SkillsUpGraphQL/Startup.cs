using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SkillsUpGraphQL.DataAccess.Repositories;
using SkillsUpGraphQL.DataBase;
using SkillsUpGraphQL.Queries;
using SkillsUpGraphQL.Schema;
using SkillsUpGraphQL.Types;

namespace SkillsUpGraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddScoped<ITrainersRepository, TrainersRepository>();

            services.AddDbContext<SkillsUpContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:SkillsUpDb"]));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<TrainerQuery>();
            services.AddScoped<TrainerType>();
            services.AddSingleton<ISchema, SkillUpSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SkillsUpContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();

            db.SeedData();

        }
    }
}
