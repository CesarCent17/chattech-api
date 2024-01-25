using chattech_users.DataSource;
using chattech_users.Interfaces;
using chattech_users.Services;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

namespace chattech_users.Dependencies
{
    public static class ServicesDependency
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            DotEnv.Load();
            string SqlServerConnection = Environment.GetEnvironmentVariable("SQLSERVER");
            services.AddDbContext<ChattechDbContext>(options =>
                options.UseSqlServer(SqlServerConnection)
            );
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(Program));
        }
    }
}
