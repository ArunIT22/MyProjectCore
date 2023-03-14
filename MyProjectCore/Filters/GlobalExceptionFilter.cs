using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MyProjectCore.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;
                int statusCode;
                if (exception is NullReferenceException)
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                }
                else if (exception is DivideByZeroException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (exception is InvalidOperationException)
                {
                    statusCode = (int)HttpStatusCode.Forbidden;
                }
                else
                {
                    statusCode = (int)HttpStatusCode.InternalServerError;
                }

                _logger.LogError($"Global Exception Filter - Error In {context.ActionDescriptor.DisplayName}, Message :{exception.Message}, Status Code :{statusCode}");
                context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
            }
        }
    }
}
