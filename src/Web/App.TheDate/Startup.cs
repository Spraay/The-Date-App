﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DAO;
using Microsoft.AspNetCore.Identity.UI.Services;
using Core.Services.Abstract;
using AutoMapper;
using Core.Services;
using Core.Repositories;
using Core.Models.Entities;
using Core.Repositories.Abstract;
using Infrastructure.DAO.Data;
using System;
using Swashbuckle.AspNetCore.Swagger;

namespace Web.TheDate
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(
                            Configuration.GetConnectionString("ProductionDbConnection")));
            else
                services.AddDbContext<ApplicationDbContext>(options =>
                        //options.UseSqlite("Data Source=localdatabase.db"));
                        options.UseSqlServer(
                            Configuration.GetConnectionString("DevelopmentDbConnection")));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IUserInterestsService, UserInterestsService>();

            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageLikeService, ImageLikeService>();
            services.AddScoped<IImageCommentRepository, ImageCommentRepository>();

            services.AddScoped<IVoteRepository, VoteRepository>();

            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddTransient<IConversationService, ConversationService>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddScoped<IFriendService, FriendService>();
            
            services.AddScoped<IMeetService, MeetService>();

            services.AddTransient<IExploreService, ExploreService>();
           
            services.AddAutoMapper();

            services.AddSignalR();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddJsonOptions(_ => _.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("alpha", new Info { Title = "My API", Version = "alpha" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
          IHostingEnvironment env,
          ApplicationDbContext context,
          RoleManager<Role> roleManager,
          UserManager<User> userManager
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/alpha/swagger.json", "My API Alpha");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DummyData.Initialize(context, userManager, roleManager).Wait();// seed here

        }
    }
}
