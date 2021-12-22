using Almostengr.PetFeeder.BackEnd.Interfaces;
using Almostengr.PetFeeder.BackEnd.Relays;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.BackEnd.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Almostengr.PetFeeder.BackEnd
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
            services.AddSingleton<IFeedingRelay, MockFoodBowlRelay>();
            // services.AddSingleton<IWaterBowlRelay, MockWaterBowlRelay>();
            // services.AddSingleton<IWaterLevelRelay, MockWaterLevelRelay>();

            services.AddSingleton<IFeedingService, MockFoodBowlService>();
            // services.AddSingleton<IWaterBowlService, MockWaterBowlService>();
            services.AddSingleton<IPowerService, MockPowerService>();

            services.AddHostedService<FeedingWorker>();
            // services.AddHostedService<WaterBowlWorker>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Almostengr.PetFeeder.BackEnd", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Almostengr.PetFeeder.BackEnd v1"));

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
