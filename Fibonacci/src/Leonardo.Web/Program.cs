var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapGet("/Fibonacci", 
    async () => Leonardo.Fibonacci.RunAsync(new []{"44", "43"}));

