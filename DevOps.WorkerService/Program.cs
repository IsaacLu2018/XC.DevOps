using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevOps.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static ILoggerRepository repository { get; set; }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IConfiguration>(hostContext.Configuration);
                    services.AddHostedService<Worker>();
                    services.AddLogging();

                    // 配置日志
                    repository = LogManager.CreateRepository("NETCoreRepository");
                    string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
                    string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
                    string configFilePath = assemblyDirPath + "\\log4net.config";
                    XmlConfigurator.Configure(repository, new FileInfo(configFilePath));
                    services.AddSingleton<ILog>(LogManager.GetLogger(repository.Name, "ExceptionLog"));
                    
                }).UseWindowsService();
    }
}
