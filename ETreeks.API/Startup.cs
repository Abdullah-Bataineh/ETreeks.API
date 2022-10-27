using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Common;
using ETreeks.INFRA.Repository;
using ETreeks.INFRA.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETreeks.API
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
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Trainer>, TrainerRepository>();
            services.AddScoped<IRepository<About>, AboutRepository>();
            services.AddScoped<IRepository<ContactInfo>, ContactInfoRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Login>, LoginRepository>();
            services.AddScoped<IRepository<ContactU>, ContactUsRepository>();
            services.AddScoped<IRepository<Course>, CourseRepository>();
            services.AddScoped<IRepository<TrainerCourse>, TrainerCourseRepository>();
            services.AddScoped<IRepository<Role>, RoleRepository>();


            services.AddScoped<IService<Category>, CategoryService>();
            services.AddScoped<IService<Trainer>, TrainerService>();
            services.AddScoped<IService<ContactInfo>, ContactInfoService>();
            services.AddScoped<IService<User>, UserService>();
            services.AddScoped<IService<About>, AboutService>();
            services.AddScoped<IService<Login>, LoginService>();
            services.AddScoped<IService<ContactU>, ContactUsService>();
            services.AddScoped<IService<Course>, CourseService>();
            services.AddScoped<IService<TrainerCourse>, TrainerCourseService>();
            services.AddScoped<IService<Role>, RoleService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
