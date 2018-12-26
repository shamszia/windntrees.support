using Application.Core.Data;
using Application.Core.Models;
using Application.Core.Models.Configuration;
using Application.Core.Services;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;

namespace Application.Core
{
    public class Startup
    {
        #region APP
        private static IApplicationBuilder _app = null;
        public static IApplicationBuilder APP
        {
            get
            {
                return _app;
            }
        }
        #endregion

        #region ENV
        private static IHostingEnvironment _env = null;
        public static IHostingEnvironment ENV
        {
            get
            {
                return _env;
            }
        }
        #endregion

        #region Services
        private static IServiceCollection _services = null;
        public static IServiceCollection Services
        {
            get
            {
                return _services;
            }
        }
        #endregion

        #region Configuration
        private static IConfiguration _configuration = null;
        public static IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }
        #endregion

        #region Antiforgery
        private static IAntiforgery _antiforgery = null;
        public static IAntiforgery Antiforgery
        {
            get
            {
                return _antiforgery;
            }
        }
        #endregion

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = options.FormFieldName;
                options.HeaderName = options.FormFieldName;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<Seed>();

            // Add localization support
            services.AddLocalization();

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            // Required for use with session object 
            // to extract values using extender methods
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IAntiforgery antiforgery, IOptions<ApplicationSettings> options, Seed seed)
        {
            _app = app;
            _antiforgery = antiforgery;

            if (options.Value.SetupAdminAccount)
            {
                seed.Fill();
            }

            string[] supportedLocales = options.Value.SupportedLocales;
            List<CultureInfo> supportedCultures = new List<CultureInfo>();

            foreach (string locale in supportedLocales)
            {
                supportedCultures.Add(new CultureInfo(locale));
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(options.Value.DefaultLocale),
                
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            if (ENV.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
