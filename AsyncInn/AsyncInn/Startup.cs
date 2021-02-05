using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Interfaces.Services;
using AsyncInn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AsyncInn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
      
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<AsyncInnDbContext>(options => {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IRoom, RoomRepository>();
            services.AddTransient<IHotel, HotelsRepository>();
            services.AddTransient<IAmenity, AmenitiesRepository>();
            services.AddTransient<IHotelRoom, HotelRoomRepository>();
            services.AddTransient<IUserService, IdentityUserService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Async-Inn",
                    Version = "v1"

                });


            });
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                
            })
            .AddEntityFrameworkStores<AsyncInnDbContext>();


            services.AddScoped<JwtTokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
               options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
            });
            services.AddAuthorization(options =>
            {
                
                options.AddPolicy("Create Hotel", policy => policy.RequireClaim("permissions", "Create Hotel"));
                options.AddPolicy("See Hotels", policy => policy.RequireClaim("permissions", "See Hotels"));
                options.AddPolicy("Update Hotel", policy => policy.RequireClaim("permissions", "Update Hotel"));
                options.AddPolicy("Delete Hotel", policy => policy.RequireClaim("permissions", "Delete Hotel"));
                options.AddPolicy("Create HotelRoom", policy => policy.RequireClaim("permissions", "Create HotelRoom"));
                options.AddPolicy("See HotelRooms", policy => policy.RequireClaim("permissions", "See HotelRooms"));
                options.AddPolicy("Update HotelRooms", policy => policy.RequireClaim("permissions", "Update HotelRooms"));
                options.AddPolicy("Delete HotelRooms", policy => policy.RequireClaim("permissions", "Delete HotelRooms"));
                options.AddPolicy("Create Rooms", policy => policy.RequireClaim("permissions", "Create Rooms"));
                options.AddPolicy("See Rooms", policy => policy.RequireClaim("permissions", "See Rooms"));
                options.AddPolicy("Update Rooms", policy => policy.RequireClaim("permissions", "Update Rooms"));
                options.AddPolicy("Delete Rooms", policy => policy.RequireClaim("permissions", "Delete Rooms"));
                options.AddPolicy("Create Amenity", policy => policy.RequireClaim("permissions", "Create Amenity"));
                options.AddPolicy("See Amenities", policy => policy.RequireClaim("permissions", "See Amenities"));
                options.AddPolicy("Add Amenity to Room", policy => policy.RequireClaim("permissions", "Add Amenity to Room"));
                options.AddPolicy("Delete Amenity From Room", policy => policy.RequireClaim("permissions", "Delete Amenity From Room"));
                options.AddPolicy("Update Amenity", policy => policy.RequireClaim("permissions", "Update Amenity"));
                options.AddPolicy("Delete Amenity", policy => policy.RequireClaim("permissions", "Delete Amenity"));

            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";

            });
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
                options.RoutePrefix = "";
            });
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseAuthentication();
        }
        
    }
}
