
using System.Net;
using System.Text.Json;

namespace JobTrackerAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception)
            {

                await HandleExceptionAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (Int32)HttpStatusCode.InternalServerError;

            var response = new
            {
                Success = false,
                Message = "Internal server error",
                Data = (object)null,
                Errors = (object)null
            };

            return context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(response));
        }
    }
}
