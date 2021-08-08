using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Core.Queue.Model;
using RabbitMQ.Core.Queue.Template;
using RabbitMQ.Core.Queue.Template.Implement;
using RabbitMQ.Hosts;
using UtilKits.RabbitMQ;
using Autofac;
using UtilKits.Reflection;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace RabbitMQ
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
            services.AddControllers();
            services.AddSingleton<ConsumerBase<MessageQueue>, TemplateConsumer>();
            services.AddHostedService<TemplateQueueHostService>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assembly = AssemblyHelper.GetAssemblies("RabbitMQ").ToArray();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
