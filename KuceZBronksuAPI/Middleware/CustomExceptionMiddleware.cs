namespace KuceZBronksuAPI.Middleware
{
    public class CustonExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustonExceptionHandlerMiddleware> _logger;
        public CustonExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustonExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception:{ex.StackTrace}, message:{ex.Message}");
            }
        }
    }
}
