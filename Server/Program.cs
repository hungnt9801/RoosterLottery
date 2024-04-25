using Microsoft.AspNetCore.Hosting;

namespace RoosterLottery.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, configuration) =>
                 {
                     IHostEnvironment env = hostingContext.HostingEnvironment;
                     Console.WriteLine("ASPNETCORE_ENVIRONMENT:" + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
                     Console.WriteLine("env.EnvironmentName:" + env.EnvironmentName);

                     var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? env.EnvironmentName;

                     configuration
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"secrets/appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                         .AddEnvironmentVariables();
                     Console.WriteLine("EnvironmentName:" + environmentName);
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}

