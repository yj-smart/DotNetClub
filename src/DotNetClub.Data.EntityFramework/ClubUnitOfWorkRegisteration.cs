using DotNetClub.Data.EntityFramework.Context;
using DotNetClub.Domain.Consts;
using Shared.Infrastructure.UnitOfWork.EntityFramework;
using System.Reflection;

namespace DotNetClub.Data.EntityFramework
{
    /// <summary>
    /// 工作单元注册
    /// </summary>
    public class ClubUnitOfWorkRegisteration : UnitOfWorkRegisteration<ClubContext>
    {
        public override string Name => UnitOfWorkNames.EntityFramework;

        public override Assembly[] EntityAssemblies => new Assembly[] { Assembly.Load(new AssemblyName("DotNetClub.Domain")) };

        public override Assembly[] RepositoryAssemblies  => new Assembly[] { Assembly.Load(new AssemblyName("DotNetClub.Data.EntityFramework")) };
    }
}
