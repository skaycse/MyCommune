using static System.Net.Mime.MediaTypeNames;

namespace MyCommune.Custom.Middlewares
{
    public class RedirectIfNotLoggedInMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectIfNotLoggedInMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                var returnUrl = context.Request.Path + context.Request.QueryString;
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    context.Response.Cookies.Append("ReturnUrl", returnUrl);
                }
            }

            await _next(context);
        }
    }

}
