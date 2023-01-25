using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _nest;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate nest,
        ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _logger = logger;
            _nest = nest;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _nest(context);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message,
                    ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

            }
        }
    }
}