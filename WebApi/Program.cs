using DataAccess.Concrete;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    DataGenerator.Initialize(services);
            //}

            //host.Run();


            //var host = CreateWebHostBuilder(args).Build();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DataGenerator.Initialize(services);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //WebHost.CreateDefaultBuilder(args)
        //  .UseStartup<Startup>()
        //  .UseKestrel(options =>
        //  {
        //      options.ListenAnyIP(Int32.Parse(System.Environment.GetEnvironmentVariable("PORT")));
        //  });
    }
}
