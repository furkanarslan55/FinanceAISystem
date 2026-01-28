namespace FinanceAI.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new { Message = "Sistemde bir hata oluştu.", Detail = ex.Message };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
