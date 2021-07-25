using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Almostengr.PetFeeder.Worker.Workers;
using Almostengr.PetFeeder.Common.Client.Interface;
using Almostengr.PetFeeder.Common.Client;

namespace Almostengr.PetFeeder.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Pet Feeder Help");
            Console.WriteLine();
            Console.WriteLine("For more information about this Pet Feeder,");
            Console.WriteLine("visit https://thealmostengineer.com/petfeeder");
            Console.WriteLine();
            Console.WriteLine(typeof(Program).Assembly.ToString());
            Console.WriteLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<FoodBowlWorker>();
                    // services.AddHostedService<FoodStorageWorker>();
                    services.AddHostedService<NightLightWorker>();
                    services.AddHostedService<WaterBowlWorker>();
                    services.AddHostedService<WaterStorageWorker>();

                    services.AddSingleton<IFeedingClient, FeedingClient>();
                    services.AddSingleton<INightLightClient, NightLightClient>();
                    services.AddSingleton<IScheduleClient, ScheduleClient>();
                    services.AddSingleton<ISettingClient, SettingClient>();
                });
    }
}
