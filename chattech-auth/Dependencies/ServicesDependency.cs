using chattech_auth.DataSource;
using chattech_auth.Interface;
using chattech_auth.Interfaces;
using chattech_auth.Services;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace chattech_auth.Dependencies
{
    public class ServicesDependency
    {
        public static void AddServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            DotEnv.Load();
            string SqlServerConnection = Environment.GetEnvironmentVariable("SQLSERVER");
            services.AddDbContext<ChattechDbContext>(options =>
                options.UseSqlServer(SqlServerConnection)
            );
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                   
                };
            });
            services.AddAuthorization();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
