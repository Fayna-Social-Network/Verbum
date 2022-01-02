namespace Verbum.WebApi.Middleware
{
    public static class CustomExceptionHandleMiddlewareExtention
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandleMiddleware>();
        }
    }
}
