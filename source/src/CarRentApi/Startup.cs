using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Application;
using CarRentApi.CarManagement.Infrastructure;
using CarRentApi.Common;
using CarRentApi.CustomerManagement.Application;
using CarRentApi.CustomerManagement.Infrastructure;
using CarRentApi.ReservationManagement.Application;
using CarRentApi.ReservationManagement.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CarRentApi
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

            services.AddTransient<CarClassService>();
            services.AddScoped<CarClassRepo>();

            services.AddTransient<CarClassRepo>();
            services.AddScoped<ContextFactory>();

            services.AddTransient<CarService>();
            services.AddScoped<CarRepo>();

            services.AddTransient<CarRepo>();
            services.AddScoped<ContextFactory>();

            services.AddTransient<CustomerService>();
            services.AddScoped<CustomerRepo>();

            services.AddTransient<CustomerRepo>();
            services.AddScoped<ContextFactory>();

            services.AddTransient<ReservationService>();
            services.AddScoped<ReservationRepo>();

            services.AddTransient<ReservationRepo>();
            services.AddScoped<ContextFactory>();


            services.AddAutoMapper(typeof(CarManagement.Infrastructure.Mapper));
            services.AddAutoMapper(typeof(CustomerManagement.Infrastructure.Mapper));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRentApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRentApi v1"));
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
