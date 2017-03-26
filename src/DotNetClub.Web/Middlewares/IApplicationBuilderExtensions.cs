using Microsoft.AspNetCore.Builder;

namespace DotNetClub.Web.Middlewares
{
    /// <summary>
    /// IApplicationBuilder扩展
    /// </summary>
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExecuteTime(this IApplicationBuilder app)
        {
            //向应用程序的请求管道添加中间件类型
            return app.UseMiddleware<ExecuteTimeMiddleware>();
        }
    }
}
