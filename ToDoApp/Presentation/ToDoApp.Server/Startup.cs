using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using MediatR;
using MediatR.Pipeline;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Queries;
using ToDoApp.Identity.JwtToken;
using ToDoApp.Identity.User;
using ToDoApp.Repository;
using ToDoApp.Repository;
using ToDoApp.Repository.ToDo;
using ToDoApp.Server.Extensions;
using ToDoApp.Server.Services;

namespace ToDoApp.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddDbContext<ToDoDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ToDoDataConnection")));
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddMediatR(typeof(GetToDoListQuery).GetTypeInfo().Assembly);
            services.AddSwagger();
            services.AddIocContainerServices();
            services.AddIdentity(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
                });
            }

            app.UseClientSideBlazorFiles<Client.Blazor.Program>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<ToDoApp.Client.Blazor.Program>("index.html");
            });
        }
    }
}
