using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoApp.Repository;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Queries;
using ToDoApp.Repository;
using ToDoApp.Repository.Tasks;

namespace ToDoApp.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient<IToDoRepository, ToDoRepository>();

            services.AddMediatR(typeof(GetToDoListQuery).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "api/{controller}/{action}/{id?}");
            });

            app.UseBlazor<Client.Startup>();
            app.UseBlazorDebugging();
        }
    }
}
