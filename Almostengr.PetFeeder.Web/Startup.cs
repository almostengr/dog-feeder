using System.Net.Http.Headers;
using Almostengr.PetFeeder.Web.Data;
using Almostengr.PetFeeder.Web.InputSensor;
using Almostengr.PetFeeder.Web.Relays;
using Almostengr.PetFeeder.Web.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Almostengr.PetFeeder.Web
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
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });

            services.AddControllersWithViews();

                        services.AddControllers();

            // repositories

            // services.AddScoped<IAlarmRepository, AlarmRepository>();
            // services.AddScoped<IFeedingRepository, FeedingRepository>();
            // services.AddScoped<IScheduleRepository, ScheduleRepository>();
            // services.AddScoped<ISettingRepository, SettingRepository>();
            // services.AddScoped<IWateringRepository, WateringRepository>();
            
            services.AddTransient<IAlarmRepository, AlarmRepository>();
            services.AddTransient<IFeedingRepository, FeedingRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ISettingRepository, SettingRepository>();
            services.AddTransient<IWateringRepository, WateringRepository>();

            // database
            services.AddDbContext<PetFeederDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DbConnection")));

            // relays

            // services.AddSingleton<IFoodBowlRelay, FoodBowlRelay>();
            // services.AddSingleton<IWaterBowlRelay, WaterBowlRelay>();
            // services.AddSingleton<INightLightRelay, NightLightRelay>();

            services.AddSingleton<IFoodBowlRelay, MockFoodBowlRelay>();
            services.AddSingleton<IWaterBowlRelay, MockWaterBowlRelay>();
            services.AddSingleton<INightLightRelay, MockNightLightRelay>();

            // input sensors

            // services.AddSingleton<IWaterInputSensor, WaterSignalInput>();
            // services.AddSingleton<IFoodStorageInputSensor, FoodStorageInputSensor>();

            services.AddSingleton<IWaterBowlInputSensor, MockWaterBowlInputSensor>();
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
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Feeding}/{action=Index}/{id?}");
                // endpoints.MapControllers();
            });
        }
    }
}
