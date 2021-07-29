using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Almostengr.PetFeeder.Web.Client.Interface;
using Almostengr.PetFeeder.Web.Client;
using Almostengr.PetFeeder.Monitor.Workers;

namespace Almostengr.PetFeeder.Monitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(typeof(Program).Assembly.ToString());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<FoodBowlWorker>();
                    services.AddHostedService<NightLightWorker>();
                    services.AddHostedService<WaterBowlWorker>();

                    services.AddSingleton<IFeedingClient, FeedingClient>();
                    services.AddSingleton<INightLightClient, NightLightClient>();
                    services.AddSingleton<IScheduleClient, ScheduleClient>();
                    services.AddSingleton<ISettingClient, SettingClient>();
                    services.AddSingleton<IWateringClient, WateringClient>();
                });
    }
}
