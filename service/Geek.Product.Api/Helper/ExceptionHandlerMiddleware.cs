using System.Net;
using System.Text.Json;

namespace Geek.Product.Api.Helper
{
    public class ExceptionHandlerMiddleware
    {
        private const string messageRequest = "Ocorreu um erro inesperado no sistema";
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private string error = "";

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case BusinessException ex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        error = ex.Message;
                        break;
                    case ArgumentNullException ex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        error = ex.Message;
                        break;
                    case ArgumentException ex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        error = ex.Message;
                        break;
                    default:
                        _logger.LogError(error, exception.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        error = messageRequest;
                        break;
                }

                var result = JsonSerializer
                    .Serialize(new
                    {
                        Sucess = false,
                        Message = error
                    });

                await response.WriteAsync(result);
            }
        }
    }
}
