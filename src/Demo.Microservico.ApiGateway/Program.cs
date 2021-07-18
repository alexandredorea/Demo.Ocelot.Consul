using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo.Microservico.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContexto, config) =>
                {
                    config
                        .SetBasePath(hostContexto.HostingEnvironment.ContentRootPath)
                        .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostContexto.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostContexto.HostingEnvironment.EnvironmentName}.json")
                        .AddJsonFile($"ocelot.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"ocelot.{hostContexto.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"ocelot.{hostContexto.HostingEnvironment.EnvironmentName}.json")
                        .AddEnvironmentVariables()
                        .Build();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging => logging.AddConsole());
    }
}