using Library.Middlewares;

namespace Library.Middlewares
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<TrackMiddleware> _logger;

        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
            //_logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                await context.Response.WriteAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent("shabbat today - the service is off!!!", System.Text.Encoding.UTF8, "application/json")
                }.ToString());
            }
            else
            {
                await _next(context);
            }
        }
    }
}
public static class ShabbatMiddlewareExtensions
{
    public static IApplicationBuilder UseShabbatCheck(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ShabbatMiddleware>();
    }
}
