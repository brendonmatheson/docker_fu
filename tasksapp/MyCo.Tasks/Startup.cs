// Docker for .NET Developers
// Copyright © 2017, Brendon Matheson
//
// This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
//
// The repository for these materials is: https://github.com/brendonmatheson/px_docker_dotnet
//
// This material is published under the terms of the Creative Commons BY-NC-ND license.  See
// https://creativecommons.org/licenses/by-nc-nd/4.0 for details

namespace MyCo.Tasks
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using MyCo.Tasks.Api;
    using MyCo.Tasks.Repository;
    using MyCo.Tasks.Repository.Impl.EntityFramework;
    using Serilog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(NodeNameHeaderFilter));
            });

            bool useInMemDatabase = this.Configuration.GetValue<bool>("UseInMemDatabase");

            if (useInMemDatabase)
            {
                services.AddDbContext<TasksContext>(x => x.UseInMemoryDatabase("Tasks"));
            }
            else
            {
                services.AddDbContext<TasksContext>(x => x.UseSqlServer("Server=db,1433; Database=Tasks; User ID=sa; Password=p@ssw0rz@#"));
                //services.AddDbContext<TasksContext>(x => x.UseSqlServer("Server=127.0.0.1,1401; Database=Tasks; User ID=sa; Password=p@ssw0rz@#"));
            }

            services.AddScoped(
                typeof(TasksRepository),
                typeof(EntityFrameworkTasksRepository));

        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            loggerFactory.AddFile("logs/tasks-{Date}.log");

            app.UseMvc();
        }
    }
}
