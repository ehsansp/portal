using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Web.Auth;


namespace PortalBuilder.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuraion, IHostingEnvironment env)
        {
            Configuration = configuraion;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ShahrContext, ShahrContext>();
            services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .Build());
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default30",
                    new CacheProfile()
                    {
                        Duration = 30
                    });
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1); services.AddDistributedMemoryCache();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ShahrContext>()
                .AddDefaultTokenProviders();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(7);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.Configure<FormOptions>(options => { options.MultipartBodyLengthLimit = 60000000; });

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/LogOut";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            }).AddGoogle(option =>
            {
                option.ClientId = "861122658055-9ttssvjp3nij4bhmfqqeanb5fub61l8n.apps.googleusercontent.com";
                option.ClientSecret = "NcmHILIfLAE4PcV29LQAh98m";
            });

            #endregion

            services.AddDbContext<ShahrContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ProjectConnection"));
                }
            );



            #region IoC



            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

         





            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });



        }
    }
}
