using Assignment5_wellingJ.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //adding new services
            services.AddDbContext<Amazon2DBContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:Amazon2Connection"]);
           });
            services.AddScoped<iLibraryRepository, EFLibraryRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoint allows to type in a category type and then page number to get to certain page
            endpoints.MapControllerRoute("categoryPage",
                "{category}/{pageNum:int}",
                new { Controller = "Home", action = "Index" });
                //endpoint allows to just type an int which will be a page
            endpoints.MapControllerRoute("page",
                "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });
                //endpoint allows to just type a category and page will automatically go to one
            endpoints.MapControllerRoute("category",
                "{category}",
                new { Controller = "Home", action = "Index", pageNum = 1 });
                //allows for P and then page number to by typed in to get to certain page
            endpoints.MapControllerRoute(
                "pagination",
                "P{pageNum}",
                new { Controller = "Home", action = "Index" });

            endpoints.MapDefaultControllerRoute();

            endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
