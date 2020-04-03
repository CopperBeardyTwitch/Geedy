using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using GeedService.Automapper;
using GeedService.DataAccess;
using GeedService.Extensions;
using GeedService.Interfaces;
using GeedService.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GeedService
{
    public class Startup
    {
        public static string ScopeRead;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                  
                })
                .AddAzureAdB2CBearer(options => Configuration.Bind("AzureAdB2C", options));

          

            services.AddTransient<IFollowingRepository,FollowingRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();

            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //    cfg.AddProfile(new AutoMapperProfile()));
            //var mapper = config.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            else
            {
                app.UseHsts();
            }
  using (var scopeservice =
                    app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scopeservice.ServiceProvider.GetService<ApplicationDbContext>();
                    DbInitilizer.Initialize(context);
                }
            ScopeRead = Configuration["AzureAdB2C:ScopeRead"];
app.UseHttpsRedirection();
            app.UseAuthentication();
            
            app.UseMvc();
        }
    }
}
