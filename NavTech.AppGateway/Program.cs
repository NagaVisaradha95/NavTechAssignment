/************************************************************************************************************
************************************************************************************************************
    File Name     :   Program.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Program file to start the project
************************************************************************************************************
************************************************************************************************************/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NavTech.AppGateway.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NavTech.AppGateway
{
    public class Program
    {
        static IConfigurationRoot _configuration;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile(Constant.APPSETTINGS).Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
