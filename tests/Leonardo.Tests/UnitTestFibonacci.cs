using Microsoft.EntityFrameworkCore;

namespace Leonardo.Tests;

public class UnitTestFibonacci
{
    [Fact]
    public async Task RunAsyncShouldRetrun8()
    {
        var builder = new DbContextOptionsBuilder<FibonacciDataContext>();
        var DataBaseName = Guid.NewGuid().ToString();
        builder.UseInMemoryDatabase(DataBaseName);
        var options = builder.Options;
        var fibonacciDataContext = new FibonacciDataContext(options);
        await fibonacciDataContext.Database.EnsureCreatedAsync();
        
        var result = await new Fibonacci(fibonacciDataContext).RunAsync(new[] { "6" });
        Assert.Equal(8,  result[0]);
    }
}