using System;
using System.Diagnostics;
using System.IO;
using Demo;
using Leonardo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddTransient<Fibonacci>();
services.AddTransient<FibonacciDataContext>();
services.AddLogging(configure => configure.AddConsole());

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfiguration configuration = new ConfigurationBuilder()    .SetBasePath(Directory.GetCurrentDirectory())    .AddEnvironmentVariables()    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)    .Build();
var applicationName = configuration.GetValue<string>("Application:Name");var applicationMessage = configuration.GetValue<string>("Application:Message");Console.WriteLine($"Application Name : {applicationName}");Console.WriteLine($"Application Message : {applicationMessage}");

var applicationSection = configuration.GetSection("Application");
var applicationConfig = applicationSection.Get<ApplicationConfig>();

var loggerFactory = LoggerFactory.Create(builder => {    builder.AddFilter("Microsoft", LogLevel.Warning)        .AddFilter("System", LogLevel.Warning)        .AddFilter("Demo", LogLevel.Debug)        .AddConsole();});var logger = loggerFactory.CreateLogger("Demo.Program");logger.LogInformation($"Application Name : {applicationConfig.Name}");logger.LogInformation($"Application Message : {applicationConfig.Message}");
var stopwatch = new Stopwatch();

stopwatch.Start();

using (var dataContext = new FibonacciDataContext())
{
    var listOfResults = await new Fibonacci(dataContext).RunAsync(args);

    foreach (var listOfResult in listOfResults)
    {
        Console.WriteLine($"Result : {listOfResult}");
    }

    stopwatch.Stop();

    Console.WriteLine("time elapsed in seconds : " + stopwatch.Elapsed.Seconds);

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