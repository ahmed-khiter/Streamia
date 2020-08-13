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
using Streamia.Models;
using Streamia.Models.Contexts;
using Streamia.Models.Extensions;
using Streamia.Models.Interfaces;
using Streamia.Models.Repositories;
using Streamia.Realtime;
using Streamia.Realtime.Containers;
using Streamia.Realtime.Interfaces;
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

            services.AddIdentity<AppUser, IdentityRole>()
                  .AddEntityFrameworkStores<StreamiaContext>()
                  .AddRoles<IdentityRole>()
                  .AddDefaultTokenProviders();

            services.AddRazorPages();

            services.AddMvc();

            services.AddSignalR(options => options.EnableDetailedErrors = true);

            services.AddDbContextPool<StreamiaContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("StreamiaMasterSQL")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton(typeof(IRemoteConnection), typeof(SshContainer));

            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CreateSubReseller", policy => 
                    policy.AddRequirements(new BuildingEntryRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, CanCreateSubResellerHandler>();

            // add local AppClaimsPrincipalFactory class to customize user
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, AppClaimsPrincipalFactory>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
                    , UserManager<AppUser> userManager, RoleManager<IdentityRole> role)
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

            SeedDataExtensions.SeedRoles(role);
            SeedDataExtensions.SeedUsers(userManager);
            //app.UseHttpsRedirection();
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
                endpoints.MapHub<StreamStatusHub>("/stream-status-hub");
                endpoints.MapHub<MovieStatusHub>("/movie-status-hub");
                endpoints.MapHub<DirectoryBrowserHub>("/directory-browser-hub");
            });
        }
    }
}
