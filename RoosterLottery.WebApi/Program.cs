//using Infrastructure.Repository;
using System.Diagnostics;

namespace Server
{
    public class Program
    {
        private readonly IConfiguration _configuration;

        public Program(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Registering the GenericRepository
            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Configure IConfiguration
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                StartClient();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void StartClient()
        {
            // Get the path to the Winform project's output directory
            string clientOutputPath = Path.Combine(
            Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
            "Client",
            "bin",
            "Debug", // Change to "Release" if you're building in Release mode
            "net8.0-windows"
            );

            // Get the path to the Winform application's executable file
            string clientPath = Path.Combine(clientOutputPath, "Client.exe");

            // Start the Winform application
            Process.Start(clientPath);
        }
    }
}