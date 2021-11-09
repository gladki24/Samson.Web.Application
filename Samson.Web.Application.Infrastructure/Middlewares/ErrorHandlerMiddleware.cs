using Microsoft.AspNetCore.Http;
using Samson.Web.Application.Infrastructure.Exceptions;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Samson.Web.Application.Infrastructure.Middlewares
{
    /// <summary>
    /// Middleware to handle BusinessLogicException on global level
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessLogicException exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                var result = JsonSerializer.Serialize(new
                {
                    message = exception?.Message
                });
                await response.WriteAsync(result);
            }
        }
    }
}
