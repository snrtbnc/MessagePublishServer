﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MQTTnet.AspNetCore;
namespace MessageServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .UseKestrel(o =>
                    {
                        o.ListenAnyIP(1883, l => l.UseMqtt());
                        o.ListenAnyIP(5000); // default http pipeline
                        o.ListenAnyIP(5001); // default http pipeline
                    })
                    .UseStartup<Startup>()
                    .Build();
    }
}
