﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace FrameWork.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("Start program");
                BuildWebHost(args).Run(); 
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging =>  {  
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                    .UseNLog()
                    .Build();
    }
}