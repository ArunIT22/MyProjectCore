using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProjectCore.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class NewCustomFilter : Attribute, IAuthorizationFilter, IResourceFilter, IActionFilter, IExceptionFilter, IResultFilter
    {
        private readonly string _name;

        public NewCustomFilter(string name)
        {
            _name = name;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine($"Authorization Filter - {_name}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action Filter - After - {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action Filter - Before - {_name}");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Resource Filter - After - {_name}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Resource Filter - Before - {_name}");
        }

        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Exception Filter Occurred :{context.Exception.Message}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Result Filter - After - {_name}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Result Filter - Before - {_name}");
        }
    }
}
