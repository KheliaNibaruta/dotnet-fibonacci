using Leonardo;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FibonacciController : ControllerBase
{

    [HttpPost]
    public async Task<List<long>> Run([FromServices] ILogger<FibonacciController> logger,
        [FromServices] Fibonacci fibonacci,
        string[] args)
    {
        logger.LogInformation("youhouuuu");
        return await fibonacci.RunAsync(args);
    }
}
