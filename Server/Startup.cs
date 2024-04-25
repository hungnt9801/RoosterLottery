using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Infrastructure.Repository;
using Server.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure.AutoMapper;
using RoosterLottery.Infrastructure;
using RoosterLottery.Infrastructure.ADO;
using RoosterLottery.Infrastructure.BackgroundJobs;

namespace RoosterLottery.WebApi
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
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<LotteryDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RoosterLottery")),
                    ServiceLifetime.Transient);

            services.AddSingleton<IDataAccessService, DataAccessService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBetRepository, BetRepository>();
            services.AddScoped<IBetService, BetService>();

            services.AddHostedService<BackgroundJobService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
