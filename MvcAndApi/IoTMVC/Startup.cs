using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IoTMVC
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
            services.AddControllersWithViews();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddDbContext<AtmosphericGasesDBContext>();
            services.AddMvc();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AtmosphericGasesDBContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 300 || context.HttpContext.Response.StatusCode == 304
                  || context.HttpContext.Response.StatusCode == 400 || context.HttpContext.Response.StatusCode == 401
                  || context.HttpContext.Response.StatusCode == 403 || context.HttpContext.Response.StatusCode == 404
                  || context.HttpContext.Response.StatusCode == 408 || context.HttpContext.Response.StatusCode == 500)
                {
                    context.HttpContext.Response.Redirect("/Error/HttpStatusCodeHandler/?statusCode=" + context.HttpContext.Response.StatusCode);
                }
            });
            db.Database.EnsureCreated();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
