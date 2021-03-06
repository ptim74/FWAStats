﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FWAStatsWeb.Data;
using FWAStatsWeb.Models;
using FWAStatsWeb.Services;
using FWAStatsWeb.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using NLog.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;
using FWAStatsWeb.Formatters;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Hosting;

namespace FWAStatsWeb
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
            services.AddDbContext<ApplicationDbContext>(options => {
                var connectionType = Configuration.GetConnectionString("Default");
                var connectionString = Configuration.GetConnectionString(connectionType);
                if (connectionType.Equals("SQLite"))
                    options.UseSqlite(connectionString);
                else if (connectionType.Equals("SqlServer"))
                    options.UseSqlServer(connectionString);
                else
                    throw new Exception($"Invalid connection type ${connectionType}");
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddOptions();
            services.Configure<ClanListOptions>(Configuration.GetSection("ClanLists"));
            services.Configure<ClashApiOptions>(Configuration.GetSection("ClashApi"));
            services.Configure<StatisicsOptions>(Configuration.GetSection("Statistics"));
            services.Configure<WeightSubmitOptions>(Configuration.GetSection("WeightSubmit"));
            services.Configure<WeightDatabaseOptions>(Configuration.GetSection("WeightDatabase"));
            services.Configure<WeightResultOptions>(Configuration.GetSection("ResultDatabase"));
            services.Configure<GoogleServiceOptions>(Configuration.GetSection("GoogleService"));

            var csvFormatterOptions = new CsvFormatterOptions();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                options.InputFormatters.Add(new CsvInputFormatter(csvFormatterOptions));
                options.OutputFormatters.Add(new CsvOutputFormatter(csvFormatterOptions));

                options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", new MediaTypeHeaderValue("application/xml"));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // Clash related services
            services.AddTransient<IClanLoader, ClanLoader>();
            services.AddTransient<IClanUpdater, ClanUpdater>();
            services.AddTransient<IMemberUpdater, MemberUpdater>();
            services.AddTransient<IClanStatistics, ClanStatistics>();
            services.AddTransient<IClashApi, ClashApi>();
            services.AddTransient<IGoogleSheetsService, GoogleSheetsService>();
            services.AddSingleton<WeightSubmitService>();
            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, HostedWebSubmitService>();

            // Caching
            services.AddMemoryCache();

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else if(env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

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
