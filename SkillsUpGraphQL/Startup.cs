using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddMvc();
            services.AddScoped<ITrainersRepository, TrainersRepository>();

            services.AddDbContext<SkillsUpContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:SkillsUpDb"]));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<TrainerQuery>();
            services.AddScoped<TrainerType>();
            //services.AddSingleton<ISchema, SkillUpSchema>();
            services.AddScoped<IDependencyResolver>
           (s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<SkillUpSchema>();
            services.AddGraphQL()
                 .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SkillsUpContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<SkillUpSchema>();
            app.UseGraphQLPlayground
               (new GraphQLPlaygroundOptions());

            db.SeedData();
        }
    }
}