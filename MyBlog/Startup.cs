using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlogBLL;
using MyBlogBLL.Interfaces;
using MyBlogBLL.Services;
using MyBlogDAL;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using MyBlogDAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Adds services to the DI
        /// </summary>
        /// <param name="services">Implementation of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MyBlog API",
                    Description = "An ASP.NET Core Web API for managing MyBlog app",
                    Contact = new OpenApiContact
                    {
                        Name = "Roman Demkiv",
                        Url = new Uri("mailto:demkiv.xcix@gmail.com")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

                options.AddSecurityRequirement(securityRequirement);
            });

            // Add DB Context
            services.AddDbContext<MyBlogDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add Identity
            services.AddIdentity<User, IdentityRole>()
                .AddSignInManager<SignInManager<User>>()
                .AddEntityFrameworkStores<MyBlogDBContext>();
                

            // Get JWT Data from config
            var authSettingSection = Configuration.GetSection("AuthSettings");
            services.Configure<AuthSettings>(authSettingSection);

            var authSettings = authSettingSection.Get<AuthSettings>();
            var key = Encoding.ASCII.GetBytes(authSettings.Secret);

            // Add JWT Authentication
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }) 
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidIssuer = authSettings.Issuer,

                        ValidateAudience = true,
                        ValidAudience = authSettings.Audience,
                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuerSigningKey = true,
                    };
                });

            // Configure DI for app services
            services.AddAutoMapper(typeof(AutomapperProfile));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            
            services
                .AddScoped<IArticleRepository, ArticleRepository>()
                .AddScoped<IBlogRepository, BlogRepository>()
                .AddScoped<ICommentRepository, CommentRepository>()
                .AddScoped<ITagRepository, TagRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
            services
                .AddScoped<IArticleService, ArticleService>()
                .AddScoped<IBlogService, BlogService>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<ITagService, TagService>();
            
        }

        /// <summary>
        /// Configures HTTP request pipeline
        /// </summary>
        /// <param name="app">Implementation of IApplicationBuilder</param>
        /// <param name="env">Implementation of IWebHostEnvironment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            CreateRoles(app.ApplicationServices).Wait();
        }

        /// <summary>
        /// Seeds roles to DB
        /// </summary>
        /// <param name="serviceProvider">Implementation of IServiceProvider</param>
        /// <returns></returns>
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            using(var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Admin", "Member" };

                foreach (var roleName in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        }
    }
}
