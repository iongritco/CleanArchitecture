using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using ToDoApp.Application.Common;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Queries;
using ToDoApp.Identity.JwtToken;
using ToDoApp.Identity.User;
using ToDoApp.Persistence;
using ToDoApp.Persistence.ToDo;
using ToDoApp.Server.Common.Services;

namespace ToDoApp.Server.Common.Extensions;

public static class ServiceExtensions
{
    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetToDoListQuery).GetTypeInfo().Assembly));
        services.AddValidatorsFromAssembly(typeof(GetToDoListQuery).GetTypeInfo().Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationHandler<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceHandler<,>));
    }

    public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>().AddEntityFrameworkStores<ToDoDataContext>().AddDefaultTokenProviders();
        services.AddAuthentication(
            options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(
            options =>
                {
                    var signingKey = Convert.FromBase64String(configuration["JwtSecret"]);
                    options.TokenValidationParameters = new TokenValidationParameters
                                                            {
                                                                ValidateIssuer = false,
                                                                ValidateAudience = false,
                                                                ValidateIssuerSigningKey = true,
                                                                IssuerSigningKey =
                                                                    new SymmetricSecurityKey(signingKey)
                                                            };
                });
        services.AddAuthorization();
    }

    public static void AddIocContainerServices(this IServiceCollection services)
    {
        services.AddSingleton<ISettings, Settings>();
        services.AddTransient<IToDoQueryRepository, ToDoQueryRepository>();
        services.AddTransient<IToDoCommandRepository, ToDoCommandRepository>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ITokenService, JwtTokenService>();
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo.API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Add Bearer token:"
            });
            c.AddSecurityRequirement((document) => new OpenApiSecurityRequirement()
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
            });
        });
    }
}
