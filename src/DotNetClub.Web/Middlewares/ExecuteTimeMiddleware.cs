using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace DotNetClub.Web.Middlewares
{
    /// <summary>
    /// 执行时间中间件
    /// </summary>
    public class ExecuteTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public ExecuteTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var body = httpContext.Response.Body;

            var ms = new MemoryStream();
            httpContext.Response.Body = ms;

            Stopwatch sw = new Stopwatch();

            try
            {
                sw.Start();
                await _next.Invoke(httpContext);
                sw.Stop();
                httpContext.Response.Headers["ExecuteTime"] = sw.ElapsedMilliseconds.ToString();
                Console.WriteLine($"RequestUrl:{httpContext.Request.Path}, ExecuteTime:{sw.ElapsedMilliseconds}");
                ms.Position = 0;
                await ms.CopyToAsync(body);
            }
            finally
            {
                httpContext.Response.Body = body;
            }
        }
    }
}
