using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderRobot.Core.MqServices.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderRobot.Operation
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
            services.Configure<RabbitMqSettings>(Configuration.GetSection("RabbitMqSettings"));
            services.AddDependencyToService();
            services.AddCap(x =>
            {
                //x.FailedRetryCount = 3;
                //x.FailedRetryInterval = 600;
                x.UseInMemoryStorage();
                var rabbitMqSettings = services.BuildServiceProvider().GetService<IOptions<RabbitMqSettings>>().Value;
                x.UseRabbitMQ(settings =>
                {
                    settings.HostName = rabbitMqSettings.Hostname;
                    settings.Port = rabbitMqSettings.Port;
                    settings.UserName = rabbitMqSettings.Username;
                    settings.Password = rabbitMqSettings.Password;
                });
            });
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
