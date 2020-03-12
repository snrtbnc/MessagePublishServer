using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using Services;

namespace MessageServer
{
    public class Startup
    {
        IMqttServer mqttServer;
        public Startup(IConfiguration configuration)
        {
           
    

            
           // mqttServer.+= MqttMessageService.MqttServer_ClientConnected;
           // mqttServer.StartAsync(optionsBuilder.Build());
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //this adds a hosted mqtt server to the services
            var mqttServerOptions = new MqttServerOptionsBuilder()
               .WithDefaultEndpointPort(5001)
               .Build();
            services
                .AddHostedMqttServer(mqttServerOptions)
                .AddMqttConnectionHandler()
                .AddMqttWebSocketServerAdapter()
                .AddConnections();
           
            services.AddSingleton<IMessageService, MqttMessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMqttEndpoint();
            app.UseMvc();
        }
    }
}
