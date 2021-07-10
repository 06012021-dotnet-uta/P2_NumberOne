using Microsoft.AspNetCore.Builder;
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
using utilities;
using data_models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FindMyPetApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FindMyPetApi", Version = "v1" });
            });
            services.AddDbContext<PetTrackerDBContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                }
            });
            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddScoped<ICustomerHandler, CustomerHandler>();
            services.AddScoped<IGetMyLocation, GetMyLocation>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FindMyPetApi v1"));
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
