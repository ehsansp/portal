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
using PortalBuilder.Core.Services;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;

namespace ShahrKoodak.Web
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
            services.AddRazorPages();
            
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
                options.EnableEndpointRouting = false;
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0); services.AddDistributedMemoryCache();



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
                options.LogoutPath = "/";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });

            #endregion

            services.AddDbContext<ShahrContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TopLearnConnection"));
            }
            );



            #region IoC

            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IStaffService, StaffService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<IBannerService, BannerService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICertificateService, CertificateService>();

            #endregion

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
                
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24 * 365;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthorization();





            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                    name: "MyAreas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(

                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });


            app.Run(async (context) => { await context.Response.SendFileAsync("friendlyError.html"); });


        }
    }
}
