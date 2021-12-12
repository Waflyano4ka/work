using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCRegistration.Domain;
using MVCRegistration.Interfaces;
using MVCRegistration.Domain.Repositories;

namespace MVCRegistration
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
            // Подключение базы данных
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(
                "Data Source=DESKTOP-DFLG2TQ\\DWORETSKIY;Initial Catalog=MVCRegistration;Integrated Security=SSPI;MultipleActiveResultSets=true;"
            ));
            services.AddControllersWithViews();
            // AddMvc - Добавляет сервисы, необходимые для работы MVC
            services.AddMvc();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IRole, RoleRepository>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Authorization}");
            });
        }
    }
}
