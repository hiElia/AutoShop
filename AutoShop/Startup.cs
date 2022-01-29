using AutoShop.Core;
using AutoShop.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AutoShop
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
             services.AddDbContext<AutoShopDbContext>(opt => opt.UseInMemoryDatabase( "autoshopdb"));

            services.AddScoped<ICarShopData, SqlCarShopData>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AutoShopDbContext>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseCookiePolicy();

            app.UseAuthentication();
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AutoShopDbContext>();

                // Seed the database.
                AddStartUpData(context);
            }
          
            
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
        }

        private void AddStartUpData(AutoShopDbContext context)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.json");
            string dataJson = File.ReadAllText(path);

            var carshopData = JsonConvert.DeserializeObject<JsonO>(dataJson);
            context.employees.AddRange(carshopData.Carshop.employees);
            context.carmodels.AddRange(carshopData.Carshop.carmodels);
            context.sales.AddRange(carshopData.Carshop.sales); 
            context.SaveChanges();
        }
    }
    public class JsonO
    {
        public Carshop Carshop {  get; set; }
    }
}
