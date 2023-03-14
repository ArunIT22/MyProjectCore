using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProjectCore.Filters
{
    public class MyAsyncActionFilter : Attribute, IAsyncActionFilter
    {
        private readonly ILogger<MyAsyncActionFilter> _logger;

        public MyAsyncActionFilter(ILogger<MyAsyncActionFilter> logger)
        {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Console.WriteLine("Action Filter Before");
            _logger.LogInformation("Action Filter - Before");
            await next();
            // Console.WriteLine("Action Filter After");
            _logger.LogInformation("Action Filter - After");
        }
    }
}
