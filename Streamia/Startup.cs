using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Streamia.Database;
using Streamia.Models;
using Streamia.Models.Interfaces;
using Streamia.Models.Repositories;
using Streamia.Realtime;
using Streamia.Security;
using Streamia.Utilies;

namespace Streamia
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

            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequiredLength = 3;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.Password.RequireDigit = false;
            });

            services.AddIdentity<AdminUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 3;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.SignIn.RequireConfirmedEmail = true;
                option.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<StreamiaContext>()
              .AddRoles<IdentityRole>()
              .AddDefaultTokenProviders();

            services.AddRazorPages();
            services.AddMvc();
            services.AddSignalR();
            services.AddDbContext<StreamiaContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("StreamiaMasterSQL")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IAuthorizationHandler, AdminHandler>();
            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            // add local AppClaimsPrincipalFactory class to customize user
            services.AddScoped<IUserClaimsPrincipalFactory<AdminUser>, AppClaimsPrincipalFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
                    , UserManager<AdminUser> userManager, RoleManager<IdentityRole> role)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            ModelBuilderExtensions.SeedRoles(role);
            ModelBuilderExtensions.SeedUsers(userManager);
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

                endpoints.MapHub<ServerStatusHub>("/server-status-hub");
                endpoints.MapControllerRoute(
                    name: "TmdbApi",
                    pattern: "{controller=TmdbApi}/{action=Index}/{id?}");
            });
        }
    }
}
