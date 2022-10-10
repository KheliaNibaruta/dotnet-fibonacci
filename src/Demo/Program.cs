using System;
using System.Diagnostics;
using System.IO;
using Demo;
using Leonardo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddTransient<Fibonacci>();
services.AddTransient<FibonacciDataContext>();
services.AddDbContext<FibonacciDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
services.AddLogging(configure => configure.AddConsole());

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)    .Build();



var applicationSection = configuration.GetSection("Application");
var applicationConfig = applicationSection.Get<ApplicationConfig>();

var stopwatch = new Stopwatch();

stopwatch.Start();

using (var serviceProvider = services.BuildServiceProvider())
{
    var logger = serviceProvider.GetService<ILogger<Program>>();
    logger.LogInformation($"Application Name : {applicationConfig.Name}");
    logger.LogInformation($"Application Message : {applicationConfig.Message}");

    var listOfResults = await serviceProvider.GetService<Fibonacci>().RunAsync(args);

    foreach (var listOfResult in listOfResults)
    {
        Console.WriteLine($"Result : {listOfResult}");
    }

    stopwatch.Stop();

    Console.WriteLine("time elapsed in seconds : " + stopwatch.Elapsed.Seconds);
}
// int Fib(int i)
// {
//     if (i <= 2) return 1;
//     return Fib(i - 1) + Fib(i - 2);
// }  
}

namespace Demo
{
    public record ApplicationConfig
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}