using Leonardo;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.MapGet("/Fibonacci", async () =>
{
    await using var dataContext = new FibonacciDataContext();
    return new Fibonacci(dataContext).RunAsync(new[] { "44", "43" });
});
app.Run();