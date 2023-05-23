using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace KuceZBronksuWEB.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {   
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message, e);
            }
        }
    }
}
