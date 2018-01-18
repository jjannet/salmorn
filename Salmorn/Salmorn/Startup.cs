using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SalmornSRV.Security.Bearer;
using SalmornSRV.Core;
using SalmornSRV.Service;
using Microsoft.EntityFrameworkCore;
using SalmornSRV.Core.Formatters;

namespace Salmorn
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

            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration["Data:ConnectionString"]));

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"
                , Configuration["GoogleCloudStorage:AcountAPIKeyPath"]);

            services.AddServices();
            services.AddCors();
            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new TextPlainInputFormatter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCors(builder =>
    builder.WithOrigins("*")
           .AllowAnyHeader());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ManageShop}/{action=DashBoard}/{id?}");
            });
        }
    }
}
