using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rookie.Ecom.Business;
using FluentValidation.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rookie.Ecom.Customer.Filters;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Rookie.Ecom.Customer
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
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
           .AddCookie("Cookies")
           .AddOpenIdConnect("oidc", options =>
           {

               options.SignInScheme = "Cookies";
               options.Authority = "https://localhost:5001/";
               //options.RequireHttpsMetadata = true;
               options.CallbackPath = "/signin-oidc";

               options.ClientId = "rookieecomcustomer";
               options.ClientSecret = "rookieecomcustomersecret";
               options.ResponseType = "id_token token";

               options.SaveTokens = true;


               options.Scope.Clear();
               options.Scope.Add("openid");
               options.Scope.Add("profile");
               options.Scope.Add("roles");
               options.ClaimActions.MapUniqueJsonKey("role", "role");
               options.GetClaimsFromUserInfoEndpoint = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   RoleClaimType = "role",
                   NameClaimType = "given_name" + "family_name"
               };
           });

            services.AddControllersWithViews(x =>
            {
                x.Filters.Add(typeof(ValidatorActionFilter));
            })
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            })
            .AddJsonOptions(ops =>
            {
                ops.JsonSerializerOptions.IgnoreNullValues = true;
                ops.JsonSerializerOptions.WriteIndented = true;
                ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddHttpContextAccessor();
            services.AddBusinessLayer(Configuration);
            services.AddSwaggerGen();
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.RootDirectory = "/Pages";
                    options.Conventions.AddPageRoute("/Home/Index", "");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
