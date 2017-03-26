using Autofac;
using DotNetClub.Core;
using DotNetClub.Core.Model.Configuration;
using DotNetClub.Core.Redis;
using DotNetClub.Core.Security;
using DotNetClub.Data.EntityFramework;
using DotNetClub.Data.EntityFramework.Context;
using DotNetClub.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Shared.Infrastructure;
using System.IO;

namespace DotNetClub.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get;}

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.AddDbContext<ClubContext>(builder =>
            {
                builder.UseSqlServer(Configuration["ConnectionString"], options =>
                {
                    options.UseRowNumberForPaging();
                    options.MigrationsAssembly("DotNetClub.Web");
                });
            }, ServiceLifetime.Transient);

            services.Configure<RedisOptions>(Configuration.GetSection("Redis").Bind)
                .Configure<SiteConfiguration>(Configuration.GetSection("Site").Bind);

            services.AddScoped<SecurityManager>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterInstance(Configuration).AsImplementedInterfaces();

            builder.RegisterType<RedisProvider>().As<IRedisProvider>().SingleInstance();

            builder.AddUnitOfWork(provider =>
            {
                provider.Register(new ClubUnitOfWorkRegisteration());
            });

            builder.RegisterModule<CoreModule>()
                .RegisterModule<EntityFrameworkModule>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            loggerFactory.ConfigureNLog(Path.Combine(env.ContentRootPath, "nlog.config"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseExecuteTime();

            app.UseMvc();
        }
    }
}
