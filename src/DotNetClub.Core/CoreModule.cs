using Autofac;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace DotNetClub.Core
{
    /// <summary>
    /// 核心模块
    /// </summary>
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            var assembly = Assembly.Load(new AssemblyName("DotNetClub.Core"));
            foreach (var typeInfo in assembly.DefinedTypes)
            {
                if (typeInfo.Name.EndsWith("Service"))
                {
                    builder.RegisterType(typeInfo.AsType());
                }
            }

            AutoMapperConfig.Configure();
        }
    }
}
