using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using salmorn.Security.Bearer.Helpers;
using Microsoft.EntityFrameworkCore;
using salmorn.Core;
using salmorn.Services;
using salmorn.Models.Commons;

namespace salmorn
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options => {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,

                           ValidIssuer = Configuration["JwtIssuerOptions:Issuer"],// "Orn.BNK48.FC",
                            ValidAudience = Configuration["JwtIssuerOptions:Audience"],// "Salmorn.BNK.C",
                            IssuerSigningKey = JwtSecurityKey.Create(Configuration["JwtIssuerOptions:SecurityKey"]) // patchanan-jiajirachote-orn-salmorn
                        };

                       options.Events = new JwtBearerEvents
                       {
                           OnAuthenticationFailed = context =>
                           {
                               Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                               return Task.CompletedTask;
                           },
                           OnTokenValidated = context =>
                           {
                               Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                               return Task.CompletedTask;
                           }
                       };
                   });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Member",
                    policy => policy.RequireClaim("MembershipId"));
            });

            services.AddDbContext<salmorn.Services.DBContext>(options => options.UseSqlServer(Configuration["Data:ConnectionString"]));

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"
                , Configuration["GoogleCloudStorage:AcountAPIKeyPath"]);


            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddServices();
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
