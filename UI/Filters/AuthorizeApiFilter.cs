using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.Filters
{
    public class AuthorizeApiFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpRequestException)
            {
                context.Result = new RedirectToActionResult(
                    "Login", "Login", null);
            }
        }
    }
}
