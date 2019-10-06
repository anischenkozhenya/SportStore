using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SportStore
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IWebHostEnvironment env) 
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{env.EnvironmentName}.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration["Data:SportStoreIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository,EFOrderRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else{
                app.UseExceptionHandler("/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes=>
            {
                routes.MapRoute(
                    name: "Error",
                    template: "Error",
                    defaults: new { Controller = "Error", action = "Error" }
                    );
                routes.MapRoute(
                    name: null,
                    template:"{category}/ Page{ page:int}",
                    defaults: new { Controller = "Product", action = "List" }
                    );
                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { Controller = "Product", action = "List",page=1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "category",
                    defaults: new { Controller = "Product", action = "List", page = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { Controller = "Product", action = "List", page = 1 }
                    );

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
