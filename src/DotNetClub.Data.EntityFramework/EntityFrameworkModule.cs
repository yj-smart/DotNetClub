using Autofac;
using System.Reflection;

namespace DotNetClub.Data.EntityFramework
{
    /// <summary>
    /// EntityFramework模块
    /// </summary>
    public class EntityFrameworkModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = Assembly.Load(new AssemblyName("DotNetClub.Data.EntityFramework"));
            foreach (var typeInfo in assembly.DefinedTypes)
            {
                if (typeInfo.Name.EndsWith("Repository"))
                {
                    builder.RegisterType(typeInfo.AsType()).AsImplementedInterfaces();
                }
            }
        }
    }
}
