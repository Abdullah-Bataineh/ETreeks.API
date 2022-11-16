using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Common;
using ETreeks.INFRA.Repository;
using ETreeks.INFRA.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policy",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AbuShehab Saadeh Shalabieh Bataineh"))
                        };
                    });







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
            services.AddScoped<ILoginRepository, LoginRepository>();
            

            services.AddScoped<IJWTRepository, JWTRepository>();
            

            services.AddScoped<IRepository<AvailableTime>, AvailableTimeRepsitory>();
            services.AddScoped<IAvailableTimeRepository, AvailableTimeRepsitory>();
            services.AddScoped<IRepository<Testimonial>,TestimonialRepository>();
            services.AddScoped<IRepository<HomePage>, HomeRepository>();
            services.AddScoped<IRepository<Reservation>, ReservationRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IVerfiyAccountRepository, LoginRepository>();



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
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IService<AvailableTime>, AvailableTimeService>();
            services.AddScoped<IService<Reservation>, ReservationService>();
            services.AddScoped<IAvailableTimeService, AvailableTimeService>();
            services.AddScoped<IService<Testimonial>, TestimonialService>();
            services.AddScoped<IService<HomePage>, HomeService>();
            services.AddScoped<IVerfiyAccountService, LoginService>();
            services.AddScoped<ILoginService, LoginService>();

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
            app.UseCors("policy");
            app.UseAuthorization();
            

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
