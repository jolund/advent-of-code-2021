using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace advent_of_code_2021
{
    public class Program2
    {
        static void Main1(string[] args)
        {

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            logger.Information("TEST");
            var host = CreateHostBuilder(args).Build();
            Worker w = host.Services.GetRequiredService<Worker>();
            w.SayHello();                        

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)   
            .ConfigureServices((hostContext, services) =>
                {
                   services.AddTransient<Worker>();                  
                })           
            .ConfigureLogging((_, logging) => 
                {
                    logging.ClearProviders();
                                        //logging.AddSimpleConsole(options => options.IncludeScopes = true);
                    logging.AddFile(AppContext.BaseDirectory);
                })
            ;
    }
}