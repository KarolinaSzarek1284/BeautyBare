using System.Diagnostics;

namespace BeautyBareAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopwach;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopwach = new Stopwatch();
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwach.Start();
            await next.Invoke(context);
            _stopwach.Stop();

            var elapsedMilliseconds = _stopwach.ElapsedMilliseconds;
            if (elapsedMilliseconds / 1000 > 4)
            { 
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMilliseconds} ms";

                _logger.LogInformation(message);
            }
        }
    }
}
