using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using SystemAuthenticator.Core.Interfaces.Mapper;
using SystemAuthenticator.Core.Interfaces.Services;
using SystemAuthenticator.Core.Mappings;
using SystemAuthenticator.Core.Services;
using SystemAuthenticator.Domain.Account;
using SystemAuthenticator.Domain.Interfaces;
using SystemAuthenticator.Infra.Data.Identity;
using SystemAuthenticator.Infra.Data.Repositories;
using SystemAuthenticator.Infra.Ioc.DependencyInjections.Extensions;
using SystemAuthenticator.Infra.Ioc.Settings;

namespace SystemAuthenticator.Infra.Ioc.DependencyInjections;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateLifetime = true,

                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };
        });

        //Connection
        services.AddScoped<IDbConnection>(db => new SqlConnection(configuration["ConnectionStringsSettings:DefaultConnection"]));

        //Mapper
        services.AddScoped<IMapper, Mapper>();

        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        //Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticate, AuthenticateService>();

        //Verifier
        services.AddScoped(typeof(IVerifierService<>), typeof(VerifierService<>));

        //Settings
        services.AddBindedSettings<ConnectionStringsSettings>();
        services.AddBindedSettings<JwtSettings>();

        return services;
    }
}
