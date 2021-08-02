using System.Net.Http.Headers;
using Almostengr.PetFeeder.Monitor.Workers;
using Almostengr.PetFeeder.Web.Client;
using Almostengr.PetFeeder.Web.Client.Interface;
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

            // ******************************************************************
            // workers
            // ******************************************************************

            services.AddHostedService<FoodBowlWorker>();
            services.AddHostedService<NightLightWorker>();
            services.AddHostedService<WaterBowlWorker>();

            // ******************************************************************
            // controllers
            // ******************************************************************

            services.AddControllersWithViews();
            services.AddControllers();

            // ******************************************************************
            // repositories
            // ******************************************************************

            services.AddTransient<IAlarmRepository, AlarmRepository>();
            services.AddTransient<IFeedingRepository, FeedingRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ISettingRepository, SettingRepository>();
            services.AddTransient<IWateringRepository, WateringRepository>();

            // ******************************************************************
            // clients
            // ******************************************************************

            services.AddSingleton<IAlarmClient, AlarmClient>();
            services.AddSingleton<IFeedingClient, FeedingClient>();
            services.AddSingleton<IListClient, ListClient>();
            services.AddSingleton<INightLightClient, NightLightClient>();
            services.AddSingleton<IPowerClient, PowerClient>();
            services.AddSingleton<IScheduleClient, ScheduleClient>();
            services.AddSingleton<ISettingClient, SettingClient>();
            services.AddSingleton<IWateringClient, WateringClient>();

            // ******************************************************************
            // database
            // ******************************************************************

            services.AddDbContext<PetFeederDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DbConnection")));

            // ******************************************************************
            // relays
            // ******************************************************************

            services.AddSingleton<IFoodBowlRelay, MockFoodBowlRelay>();
            services.AddSingleton<IWaterBowlRelay, MockWaterBowlRelay>();
            services.AddSingleton<INightLightRelay, MockNightLightRelay>();

            // ******************************************************************
            // input sensors
            // ******************************************************************

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
