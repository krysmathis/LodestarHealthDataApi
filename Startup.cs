using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LodestarHealthDataApi.Data;
using LodestarHealthDataApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LodestarHealthDataApi
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
            //TODO: Cors frameworks ala https://github.com/spooky-oysters/bangazon/blob/master/Startup.cs
            services.AddCors();
            // TODO: store connection string in a secure place
            string connection = "Data Source=LodestarHealthData.db";
            services.AddDbContext<LodestarAPIContext>(options => options.UseSqlite(connection));
            services.AddMvc();

              // Set up identity server so services like SignInManager can be injected into controllers
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LodestarAPIContext>()
                .AddDefaultTokenProviders();

            // Set up MVC service
            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Set up JWT authentication service
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";  
                options.DefaultChallengeScheme = "Jwt";              
            }).AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7A735D7B-1A19-4D8A-9CFA-99F55483013F")), 
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
                builder.WithOrigins("https://blissful-kare-a8283f.netlify.com","http://localhost:3000","http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()   
            );
            
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
