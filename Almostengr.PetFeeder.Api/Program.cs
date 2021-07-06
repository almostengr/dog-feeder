using System;
using System.Device.Gpio;
using Almostengr.PetFeeder.Api.Workers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Almostengr.PetFeeder.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ShowHelp();
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
                .UseSystemd()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<GpioController>();

                    services.AddScoped<IFoodStorageWorker, FoodStorageWorker>();
                    services.AddScoped<IWaterStorageWorker, WaterStorageWorker>();

                    services.AddScoped<IFoodBowlWorker, FoodBowlWorker>();
                    services.AddScoped<IWaterBowlWorker, WaterBowlWorker>();
                });
    }
}
